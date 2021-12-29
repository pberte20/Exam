using StregSystem.Exceptions;
using StregSystem.Loggers;
using StregSystem.Model.DataLoaders;
using StregSystem.Model.Products;
using StregSystem.Model.Transactions;
using StregSystem.Model.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;

namespace StregSystem.Model.StregSystem
{
    public class StregSystemModel
    {
    
        private List<BaseTransaction> _transactions;
        private List<Product> _products;
        private List<User> _users;
        public IEnumerable<Product> ActiveProducts
        {
            get
            {
                return _products.Where(p => p.IsActive).ToList();
            }
        }
        private TransactionLogger _transactionLogger;
        public event EventHandler<User> UserBalanceBelowTreshold;

        public StregSystemModel()
        {
            IDataLoader<User> userLoader = new UserLoader();
            IDataLoader<Product> productLoader = new ProductLoader();
            _users = 
                userLoader.LoadData(File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(),@"Data\users.csv" )).Skip(1));
        
                
            _products = 
                productLoader.LoadData(File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(),@"Data\products.csv" )).Skip(1));
            _transactions = new List<BaseTransaction>();
            foreach (User user in _users)
            {
                user.UserBalanceBelowTreshold += OnUserBalanceBelowTreshold;
            }
            _transactionLogger = new TransactionLogger();
        }
        
        public BuyProductTransaction BuyProduct(Product product, User user, decimal amount)
        {
            BuyProductTransaction transaction = new BuyProductTransaction(product, user, amount);
            TransactionExecute(transaction);
            _transactionLogger.Log(transaction);
            return transaction;
        }

        public InsertCashTransaction InsertCash(decimal amount, User user)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(amount, user);
            TransactionExecute(transaction);
            _transactionLogger.Log(transaction);
            return transaction;
        }

        public Product GetProductById(int id)
        {
            foreach (Product product in _products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }
        protected virtual void OnUserBalanceBelowTreshold(Object user, EventArgs e)
        {
            EventHandler<User> handler = UserBalanceBelowTreshold;
            handler?.Invoke(this, (User)user);
            
        }
        public IEnumerable<User> GetUsers(Func<User, bool> predicate)
        {
            return _users.Where(predicate);
        }

        public User GetUserByUserName(string userName)
        {
            User user = _users.Where(u => userName == u.UserName).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException();
            }
        }
        public IEnumerable<BaseTransaction> GetTransactions (User user, int count)
        {
            return _transactions.Where(t => t.User == user).Take(count);
        }

        public IEnumerable<Product> GetActiveProducts()
        {
            return _products.Where(p => p.IsActive);
        }
        private void TransactionExecute(BaseTransaction Basetransaction)
        {
            Basetransaction.Execute();
            _transactions.Add(Basetransaction);
        }
        public void ChangeActiveStatus(Product product, bool isActive)
        {
            product.IsActive = isActive;
        }
        public void ChangeCreditStatus(Product product, bool isCredit)
        {
            product.CanbeBoughtOnCredit = isCredit;
        }
    }
}
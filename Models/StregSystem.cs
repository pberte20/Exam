namespace Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StregSystem
    {
    
        private List<Transaction> _transactions;
        private List<Product> _products;
        private List<User> _users;
        public IEnumerable<Product> ActiveProducts
        {
            get
            {
                return _products.Where(p => p.IsActive).ToList();
            }
        }
        public event EventHandler<User> UserBalanceBelowTreshold;

        public StregSystem(List<User> users, List<Product> products)
        {
            _products = products;
            _users = users;
            _transactions = new List<Transaction>();
            foreach (User user in users)
            {
                user.UserBalanceBelowTreshold += OnUserBalanceBelowTreshold;
            }
        }
        
        public BuyProductTransaction BuyProduct(Product product, User user, decimal amount)
        {
            BuyProductTransaction transaction = new BuyProductTransaction(product, user, amount);
            transactionExecute(transaction);
            return transaction;
        }

        public InsertCashTransaction InsertCash(decimal amount, User user)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(amount, user);
            transactionExecute(transaction);
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
        public IEnumerable<Transaction> GetTransactions (User user, int count)
        {
            return _transactions.Where(t => t.User == user).Take(count);
        }

        public IEnumerable<Product> GetActiveProducts()
        {
            return _products.Where(p => p.IsActive);
        }
        private void transactionExecute(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);
        }
        public void ChangeActiveStatus(Product product, bool isActive)
        {
            product.IsActive = isActive;
        }
    }
}
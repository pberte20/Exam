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

        public IEnumerable<User> GetUsers(Func<User, bool> predicate)
        {
            return _users.Where(predicate);
        }

        public User GetUserByUserName(string userName)
        {
            User user = _users.Where(u => u.UserName == userName).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                throw new UserNotFoundException();
            }
        }


        private void transactionExecute(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);
        }
    }
}
namespace Exam
{
    using System;
    public class StregSystemCLI : IStregSystemUI
    {
        public event EventHandler<string> CommandEntered;
        private bool _running = true;
        private StregSystem _stregSystem;
        public StregSystemCLI(StregSystem stregSystem)
        {
            _stregSystem = stregSystem;
        }
        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine($"Error: {errorString}");
        }
        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine($"User {user.UserName} does not have enough cash to buy {product.Name}");
        }
        public void DisplayUserBuysProduct(BuyProductTransaction transaction)
        {
            Console.WriteLine($"User {transaction.User.UserName} bought {transaction.Product.Name}");
        }
        public void DisplayUserBuysProduct(int count, BuyProductTransaction transaction)
        {
            Console.WriteLine($"User {transaction.User.UserName} bought {count} {transaction.Product.Name}");
        }
        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"Admin command not found: {adminCommand}");
        }
        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine($"Too many arguments for command: {command}");
        }
        public void DisplayUserInfo(User user)
        {
            Console.WriteLine($"User: {user.UserName}");
            Console.WriteLine($"Balance: {user.Balance}");
        }
        public void DisplayUserNotFound(User user)
        {
            Console.WriteLine($"User {user.UserName} not found");
        }
        public void DisplayProductNotFound(Product product)
        {
            Console.WriteLine($"Product {product.Name} not found");
        }
        public void DisplayProductIsActive(Product product)
        {
            if (product.IsActive)
            {
                Console.WriteLine($"Product {product.Name} is active");
            }
            else
            {
                Console.WriteLine($"Product {product.Name} is not active");
            }
        }
        public void DisplayProductIsActiveChanged(Product product, bool isActive)
        {
            Console.WriteLine($"Product {product.Name} is {(isActive ? "active" : "not active")}");
        }
        private void DisplayProducts()
        {
            Console.WriteLine("Products:");
            foreach (Product product in _stregSystem.ActiveProducts)
            {
                Console.WriteLine(product.ToString());
            }
        }
        public void DisplayCreditStatusChanged(Product product, bool isActive)
        {
            Console.WriteLine($"Credit status changed for product {product.Name} to {isActive}");
        }
        public void DisplayCashInserted(InsertCashTransaction transaction)
        {
            Console.WriteLine($"Cash inserted: {transaction.Amount} to account {transaction.User.UserName} current balance is {transaction.User.Balance}");
        }
        public void Start()
        {
            while (_running)
            {   
                DisplayProducts();
                Console.WriteLine("Enter command:");
                string command = Console.ReadLine();
                CommandEntered?.Invoke(this, command);
                Console.ReadLine();

            }
        }
        public void Close()
        {
            _running = false;
        }
    }
}
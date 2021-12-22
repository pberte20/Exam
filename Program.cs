namespace Exam
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = GetUsers();
            List<Product> products = GetProducts();
            users.Sort();
            PrintUsers(users);
            PrintProducts(products);
            Transaction transaction  = new InsertCashTransaction(15,users[0]);
            Console.WriteLine(transaction.ToString()); 
            Console.WriteLine(users[0].Balance);
            transaction.Execute();
            Console.WriteLine(users[0].Balance);
            Transaction transaction2 = new BuyProductTransaction(products[0],users[0], products[0].Price);
            transaction2.Execute();
            Console.WriteLine(transaction2.ToString());
            Console.WriteLine(users[0].Balance);
            StregSystem stregSystem = new StregSystem(users, products, new List<Transaction>());
            stregSystem.InsertCash(15, users[0]);
            Console.WriteLine(users[0].Balance);
            Console.WriteLine(stregSystem.GetUserByUserName("grisenz"));
         }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User("Patrick", "Bertelsen", "grisenz", "Patrick@gmail.com"));
            users.Add(new User ("Simon", "prooonk", "gamer", "uglenxd@gmail.com"));
            return users;
        }
        public static void PrintUsers(List<User> users)
        {
            Console.WriteLine("Users:");
            foreach (User user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }

        public static void PrintProducts(List<Product> products)
        {
            Console.WriteLine("Products:");
            foreach (Product product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Cola",10,false));
            products.Add(new Product("Fanta", 10, false));
            products.Add(new Product("Sprite", 10, false));
            products.Add(new Product("Coffee", 5, false));
            products.Add(new Product("Party Ticket", 200, true));
            return products;

        }


    
    }

}

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
            Transaction transaction  = new InsertCashTransaction(100,users[0]);
            Console.WriteLine(transaction.ToString()); 
         }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User("Patrick", "Bertelsen", "grisenz2_", "Patrick@gmail.com"));
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

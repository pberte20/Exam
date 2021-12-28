namespace Exam
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            IDataLoader<User> userLoader = new UserLoader();
            IDataLoader<Product> productLoader = new ProductLoader();
            string DirectoryLocation = Directory.GetCurrentDirectory();
            List<User> users = 
                userLoader.LoadData(File.ReadLines(Path.Combine(Directory.GetCurrentDirectory(),@"Data\users.csv" )).Skip(1));
        
                
            List<Product> products = 
                productLoader.LoadData(File.ReadLines(Path.Combine(DirectoryLocation,@"Data\products.csv" )).Skip(1));
            users.Sort();
            StregSystem stregSystem = new StregSystem(users, products);
            IEnumerable<Product> ActiveProducts = stregSystem.GetActiveProducts();
            StregSystemCLI stregSystemCLI = new StregSystemCLI(stregSystem);
            StregSystemController controller = new StregSystemController(stregSystemCLI, stregSystem);
            stregSystemCLI.Start();
         }

        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            users.Add(new User("Patrick", "Bertelsen", "grisenz", "Patrick@gmail.com", 50));
            users.Add(new User ("Simon", "prooonk", "gamer", "uglenxd@gmail.com", 50));
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
        // public static List<Product> GetProducts()
        // {
        //     List<Product> products = new List<Product>();
        //     products.Add(new Product("Cola",10,false, true));
        //     products.Add(new Product("Fanta", 10, false, true));
        //     products.Add(new Product("Sprite", 10, false, true));
        //     products.Add(new Product("Coffee", 5, false, true));
        //     products.Add(new Product("Party Ticket", 200, true, true));
        //     return products;

        // }


    
    }

}

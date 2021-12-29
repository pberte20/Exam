using System.Collections.Generic;
using StregSystem.Model.Users;

namespace StregSystem.Model.DataLoaders
{

    public class UserLoader : IDataLoader<User>
    {
        public List<User> LoadData(IEnumerable<string> lines)
        {
            List<User> users = new List<User>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string FirstNameString = parts[1];
                string LastNameString = parts[2];
                string UserNameString = parts[3];
                string BalanceString = parts[4];
                string EmailString = parts[5];

                User user = new User(FirstNameString, LastNameString, UserNameString, EmailString, decimal.Parse(BalanceString)/100);
                users.Add(user);

                
            }
            return users;
        }
    }
}
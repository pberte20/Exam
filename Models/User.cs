using System.Text.RegularExpressions;
using System;
namespace StregSystem.Model.Users
{
       public class User:IComparable<User>
    {

        public event EventHandler<EventArgs> UserBalanceBelowTreshold;
        public int CompareTo(User other)
        {
            if (this.Id > other.Id)
            {
                return 1;
            }
            else if (this.Id < other.Id)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public User(string firstname, string lastname, string userName, string email, decimal balance)
        {
            this.FirstName = firstname;
            this.lastName = lastname;
            this.Email = email;
            this.UserName = userName;
            this.Id = IdCounter++;
            this.Balance = balance;
            
        }
        private static int balanceTreshold = 50;
        private int Id;
        private static int IdCounter = 0;

        public string FirstName
        {
            get { return firstName; }
            set {
                if(value == null )
                {
                    throw new ArgumentNullException("First name cannot be null");
                }
                else
                {
                    firstName = value;
                }
            }
        }
        private string firstName;
        public string LastName{
            get { return lastName; }
            set 
            {
                if(value == null)
                {
                    throw new ArgumentNullException("Last name cannot be null");
                }
                else
                {
                    lastName = value;
                }
            }
        }

        private string lastName;
        public string UserName{
            get { return userName; }
            set {
                    if (UserNameRegex.IsMatch(value))
                    {
                        userName = value;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid username");
                    }
                }
        }
        private Regex UserNameRegex = new Regex(@"[a-z0-9'_']$");
        private string userName;


        public string Email
        {
            get { return email; }
            set {
                if(EmailRegex.IsMatch(value))
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentException("Invalid email");
                }
            }
        }
        private string email;
        private Regex EmailRegex = new Regex(@"^[a-zA-Z0-9'_''-''.'',']+@[a-zA-Z0-9'.']+\.+[a-zA-Z0-9]+$");
        public decimal Balance
        {
            get { return balance; }
            set 
            { 
                balance = value;
                if (balance < balanceTreshold)
                {
                    OnUserBalanceBelowTreshold(EventArgs.Empty);
                }
            }
        }
        private decimal balance;
        public delegate string UserBalanceNotification(User user, decimal balance);
    
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Email} ";
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        protected virtual void OnUserBalanceBelowTreshold(EventArgs e)
        {
            UserBalanceBelowTreshold?.Invoke(this, e);
        }

    }

   
}

namespace Exam
{
    using System;
       class User:IComparable<User>
    {

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
        public User(string firstname, string lastname, string email)
        {
            this.FirstName = firstname;
            this.lastName = lastname;
            this.Email = email;
            this.Id = IdCounter++;
            
        }
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
                if(value == null )
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
        public string UserName{get;set;}

        string Email;
        public decimal Balance
        {
            //TODO implement negative balance check
            get { return balance; }
            set { 
                if (balance - value <50)
                {
                    Console.WriteLine("Balance is now less than 50");
                }
                balance = value; 
                }
        }
        private decimal balance;
        //TODO implement delegate
        public delegate string UserBalanceNotification(User user, decimal balance);
    
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Email} ";
        }
    }

   
}

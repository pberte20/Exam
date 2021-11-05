namespace Exam
{
    using System;
       class bruger
    {

        public bruger(string firstname, string lastname, string email, int id)
        {
            this.FirstName = firstname;
            this.lastName = lastname;
            this.Email = email;
            this.id = id;
            
        }
        int id;

        public string FirstName
        {
            get { return firstName; }
            set {
                if(value == null )
                {
                    throw new System.NullReferenceException();
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
                if(value == null || value == "")
                {
                    throw new System.NullReferenceException();
                }
                else
                {
                    lastName = value;
                }
            }
        }

        private string lastName;
        string UserName;

        string Email;
        public int Balance
        {
            get { return balance; }
            set { 
                if (balance - value <50)
                {
                    Console.WriteLine("Balance is now less than 50");
                }
                balance = value; 
                }
        }
        private int balance;
        public override string ToString()
        {
            return $"{FirstName} {LastName} {Email} ";
        }
    }
}

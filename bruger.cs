namespace Exam
{
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
                if(value == null || value == "")
                {
                    throw new System.Exception("First name is empty");
                }
                else
                {
                    firstName = value;
                }
            }
        }
        private string firstName;
        string lastName;
        string UserName;

        string Email;

        int Balance;
    }
}

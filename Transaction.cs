namespace Exam
{  
    using System;
    public abstract class Transaction
        {
        public Transaction(decimal amount, User user)
            {
                this.Id = IdCounter++;
                this.User = user;
                this.Amount = amount;
                this.Date = DateTime.Now;
            }

            public abstract void Execute();
    
            public int Id { get; set; }
            protected static int IdCounter = 1;
            public decimal Amount { 
                get
                {
                    return this.amount;}
                set
                {
                        if (value == 0)
                        {
                            throw new ArgumentException("Amount cannot be zero");
                        }
                        else
                        {
                            this.amount = value;
                    }
                }
            }
            private decimal amount;

            public User User { 
                get
                {
                    return this.user;
                }
                    
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentException("User cannot be null");
                    }
                    else
                    {
                        this.user = value;
                    }
                }
            }
            private User user;



            public DateTime Date { get; set; }
            private DateTime date;

            public override string ToString()
            {
                return $"{this.Id} | {this.Amount} | {this.User} | {this.Date}";
            }
        }
}
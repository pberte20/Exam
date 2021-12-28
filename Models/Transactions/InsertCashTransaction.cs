namespace Exam
{
    using System;
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(decimal amount, User user) 
        : base(amount, user)
        {
            this.Amount = amount;
            this.User = user;
        }
        public override void Execute()
        {
            try
            { 
                User.Balance += Amount;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
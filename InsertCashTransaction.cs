namespace Exam
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(decimal amount, User user) 
        : base(amount, user)
        {

        }
        public override void Execute()
        {
            User.Balance += Amount;
        }
    }
}
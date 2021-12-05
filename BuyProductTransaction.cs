namespace Exam
{
    public class BuyProductTransaction : Transaction
    {
        public BuyProductTransaction(Product product, User user, int amount)
            : base(amount, user)
            {
                this.Product = product;
                this.Amount = amount;
                this.User = user;
            }
        public override void Execute()
        {
            try
            {
                 User.Balance -= Amount;
            }
            catch (System.Exception)
            {
                
                throw new System.Exception("Not enough money");
            }
        }

        public Product Product { get; set; }
    }
}
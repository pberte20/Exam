namespace Exam
{
    using System;
    public class BuyProductTransaction : Transaction
    {
        public BuyProductTransaction(Product product, User user, decimal amount)
            : base(amount, user)
            {
                this.Product = product;
                this.Amount = amount;
                this.User = user;
            }
        public override void Execute()
        {
            if (this.User.Balance < this.Amount && this.Product.CanbeBoughtOnCredit == false)
            {
                throw new InsufficientCreditsException(Product, User);
            }
            else if (!Product.IsActive)
            {
                throw new ProductNotActiveException(Product);
            }
            else
            {
                this.User.Balance -= this.Product.Price * this.Amount;
            }
        }

        public override string ToString()
        {
            return $"{this.Product.Name} {this.Amount} {this.Date}";
        }
        public Product Product { get; set; }

    }
}
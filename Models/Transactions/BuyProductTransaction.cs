using System;
using StregSystem.Exceptions;
using StregSystem.Model.Products;
using StregSystem.Model.Users;
namespace StregSystem.Model.Transactions
{

    public class BuyProductTransaction : BaseTransaction
    {
        public BuyProductTransaction(Product product, User user, decimal amount)
            : base(amount, user)
            {
                this.Product = product;
                this.Amount = amount;
                this.User = user;
                this._totalPrice = this.Product.Price * this.Amount;
            }
        public override void Execute()
        {
            if (this.User.Balance < this._totalPrice && this.Product.CanbeBoughtOnCredit == false)
            {
                throw new InsufficientCreditsException(Product, User, Amount , _totalPrice);
            }
            else if (!Product.IsActive)
            {
                throw new ProductNotActiveException(Product);
            }
            else
            {
                this.User.Balance -= this.Product.Price * this.Amount;
                User.UserBalanceBelowTreshold += User_UserBalanceBelowTreshold;
            }
        }
        private void User_UserBalanceBelowTreshold(object sender, EventArgs e)
        {
            Console.WriteLine("Balance below treshold");
        }

        public override string ToString()
        {
            return $"ID {this.Id}: {this.User.UserName} bought {this.Amount} {this.Product.Name} for {this._totalPrice} at {this.Date}";
        }
        public Product Product { get; set; }
        private decimal _totalPrice;

    }
}
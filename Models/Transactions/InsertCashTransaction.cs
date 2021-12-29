using System;
using StregSystem.Model.Users;
namespace StregSystem.Model.Transactions
{

    public class InsertCashTransaction : BaseTransaction
    {
        public InsertCashTransaction(decimal amount, User user) 
        : base(amount, user)
        {
            this.Amount = amount;
            this.User = user;
        }
        public override string ToString()
        {
            return $"ID {this.Id}: {this.User.UserName} inserted {this.Amount} at {this.Date}";
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
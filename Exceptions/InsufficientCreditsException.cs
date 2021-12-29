namespace Exam
{
    using System;
    [Serializable]
    class InsufficientCreditsException : Exception
    {
        public InsufficientCreditsException() { }

        public InsufficientCreditsException(Product product, User user, decimal amount, decimal totalPrice) : 
        base(String.Format($"{user.UserName} cannot afford  {product.Name}: has {user.Balance} Streg Valuta needs {totalPrice}"))
        {

        }
    }
}
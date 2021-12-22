namespace Exam
{
    using System;
    [Serializable]
    class InsufficientCreditsException : Exception
    {
        public InsufficientCreditsException() { }

        public InsufficientCreditsException(Product product, User user) : 
        base(String.Format($"{user.UserName} cannot afford {product.Name}: has {user.Balance} Streg Valuta needs {product.Price}"))
        {

        }
    }
}
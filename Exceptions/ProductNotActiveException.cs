namespace Exam
{
    using System;
    public class ProductNotActiveException : Exception
    {
        public ProductNotActiveException()
        {
        }

        public ProductNotActiveException(Product product)
            : base(String.Format($"Product is not active: {product.ToString()}"))
        {
        }

    }
}
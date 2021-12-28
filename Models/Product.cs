namespace Exam
{
    public class Product
    {
        public Product(string name, decimal price, bool canBeBoughtOnCredit, bool isActive)
        {
            this.Name = name;
            this.Price = price;
            this.CanbeBoughtOnCredit = canBeBoughtOnCredit;
            this.IsActive = isActive;
            this.Id = IdCounter++;
        }
        public int Id{ get; set; }
        protected static int IdCounter = 1;
        public string Name{ get; set;}
        protected string name;
        public decimal Price{ get; set;}
        protected decimal price;
        public bool IsActive{ get; set;}
        public bool CanbeBoughtOnCredit{ get; set;}
        protected bool canBeBoughtOnCredit;

        public override string ToString()
        {
            return $"ID:{Id} NAME:{Name} PRICE:{Price}";
        }

    }
}

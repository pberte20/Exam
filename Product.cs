namespace Exam
{
    class Product
    {
        public Product(string name, decimal price, bool canBeBoughtOnCredit)
        {
            this.Name = name;
            this.Price = price;
            this.CanbeBoughtOnCredit = canBeBoughtOnCredit;
            //Assume that a product is active on creation
            this.IsActive = true;
            this.Id = IdCounter++;
        }
        public int Id{ get; }
        private static int IdCounter = 1;
        public string Name{ get; set;}
        private string name;
        public decimal Price{ get; set;}
        private decimal price;
        public bool IsActive{ get; set;}
        public bool CanbeBoughtOnCredit{ get; set;}
        private bool canBeBoughtOnCredit;

        public  override string ToString()
        {
            return $"{Id} {Name} {Price}";
        }

    }
}

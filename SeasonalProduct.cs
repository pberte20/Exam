namespace Exam
{
    using System;
    class SeasonalProduct
    {
        public SeasonalProduct(string name, decimal price, DateTime seasonStart, DateTime seasonEnd, bool canBeBoughtOnCredit)
        {
            this.Name = name;
            this.Price = price;
            this.SeasonStart = seasonStart;
            this.SeasonEnd = seasonEnd;
            this.Id = IdCounter++;
            this.CanbeBoughtOnCredit = canBeBoughtOnCredit;
        }
        private int Id;
        private static int IdCounter = 1;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name cannot be null");
                }    
            }
        }
        private string name;
        public bool Active;

        public decimal Price;
        private decimal price;
        public bool CanbeBoughtOnCredit;
        private bool canBeBoughtOnCredit;

        public DateTime SeasonStart;
        private DateTime seasonStart;
        public DateTime SeasonEnd;
        private DateTime seasonEnd;


        
    }

}

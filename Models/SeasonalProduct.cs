namespace Exam
{
    using System;
    class SeasonalProduct : Product
    {
        public SeasonalProduct(string name, decimal price, DateTime seasonStart, DateTime seasonEnd, bool canBeBoughtOnCredit)
            : base(name, price, canBeBoughtOnCredit)
        {
            this.SeasonStart = seasonStart;
            this.SeasonEnd = seasonEnd;
            this.Id = IdCounter++;
            this.active = true;
        }

        public bool Active;
        private bool active;
        public DateTime SeasonStart;
        private DateTime seasonStart;
        public DateTime SeasonEnd;
        private DateTime seasonEnd; 
    }

}

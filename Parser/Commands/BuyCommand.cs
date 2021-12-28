namespace Exam
{
    using System;
    public class BuyCommand : ICommand
    {
        private IStregSystemUI _ui;
        private StregSystem _stregSystem;
        private User _user;
        private Product _product;
        private int _amount;

        public BuyCommand(IStregSystemUI ui, StregSystem stregSystem, User user, Product product, int amount)
        {
            _ui = ui;
            _stregSystem = stregSystem;
            _user = user;
            _product = product;
            _amount = amount;
        }
        public BuyCommand(IStregSystemUI ui, StregSystem stregSystem, User user, Product product)
        {
            _ui = ui;
            _stregSystem = stregSystem;
            _user = user;
            _product = product;
            _amount = 1;
        }

        public void Execute()
        {
            try
            {
                _stregSystem.BuyProduct(_product, _user, _amount);
            }
            catch (Exception e)
            {
                _ui.DisplayGeneralError(e.Message);
            }
        }
    }
}
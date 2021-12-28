namespace Exam
{
    using System;
    public class AddCreditCommand : ICommand
    {
        private IStregSystemUI _ui;
        private User _user;
        private decimal _amount;
        private StregSystem _stregSystem;
        public AddCreditCommand(IStregSystemUI ui, StregSystem stregSystem, User user, decimal amount)
        {
            _ui = ui;
            _user = user;
            _amount = amount;
            _stregSystem = stregSystem;
        }
        public void Execute()
        {
            try
            {
                InsertCashTransaction transaction = _stregSystem.InsertCash(_amount , _user);
                _ui.DisplayCashInserted(transaction);
            }
            catch (Exception e)
            {
                _ui.DisplayGeneralError(e.Message);
            }
        }
    }
}
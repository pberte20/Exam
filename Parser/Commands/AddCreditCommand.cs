namespace StregSystem.Parser.Commands
{
    using System;
    using StregSystem.Model.StregSystem;
    using StregSystem.Model.Transactions;
    using StregSystem.Model.Users;
    using StregSystem.UI;

    public class AddCreditCommand : ICommand
    {
        private IStregSystemUI _ui;
        private User _user;
        private decimal _amount;
        private StregSystemModel _stregSystem;
        public AddCreditCommand(IStregSystemUI ui, StregSystemModel stregSystem, User user, decimal amount)
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
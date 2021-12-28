namespace Exam
{
    public class CreditStatusCommand : ICommand
    {
        private IStregSystemUI _ui;
        private Product _product;
        private StregSystem _stregSystem;
        private bool _status;
        public CreditStatusCommand(IStregSystemUI ui,StregSystem stregSystem, Product product, bool Status)
        {
            _ui = ui;
            _product = product;
            _status = Status;
            _stregSystem = stregSystem;
        }
        public void Execute()
        {
            _stregSystem.ChangeCreditStatus(_product, _status);
            _ui.DisplayCreditStatusChanged(_product, _status);
        }
    }
}
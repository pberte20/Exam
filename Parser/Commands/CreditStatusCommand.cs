using StregSystem.Model.Products;
using StregSystem.Model.StregSystem;
using StregSystem.UI;

namespace StregSystem.Parser.Commands
{
    public class CreditStatusCommand : ICommand
    {
        private IStregSystemUI _ui;
        private Product _product;
        private StregSystemModel _stregSystem;
        private bool _status;
        public CreditStatusCommand(IStregSystemUI ui,StregSystemModel stregSystem, Product product, bool Status)
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
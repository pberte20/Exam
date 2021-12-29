using StregSystem.UI;
using StregSystem.Model.Products;
using StregSystem.Exceptions;
using StregSystem.Model.StregSystem;

namespace StregSystem.Parser.Commands
{
    public class ActivateStatusCommand : ICommand
    {
        public ActivateStatusCommand(IStregSystemUI ui, StregSystemModel stregSystem, Product product, bool status)
        {
            _ui = ui;
            _product = product;
            _status = status;
            _stregSystem = stregSystem;
        }
        private IStregSystemUI _ui;
        private StregSystemModel _stregSystem;
        private Product _product;
        private bool _status;
        
        public void Execute()
        {
            try
            {
                 _stregSystem.ChangeActiveStatus(_product, _status);
                 _ui.DisplayProductIsActive(_product);
             }
             catch (ProductNotActiveException e)
             {
                 _ui.DisplayGeneralError(e.Message);
             }
        }
    }
}
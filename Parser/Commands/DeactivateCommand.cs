namespace Exam
{
    internal class DeactivateCommand : ICommand
    {
        public DeactivateCommand(IStregSystemUI ui, StregSystem stregSystem, Product product)
        {
            _ui = ui;
            _stregSystem = stregSystem;
            _product = product;
        }
        private IStregSystemUI _ui;
        private StregSystem _stregSystem;
        private Product _product;
        public void Execute()
        {
            try
            {
                _stregSystem.ChangeActiveStatus(_product, false);
                _ui.DisplayProductIsActive(_product);
            }
            catch (ProductNotActiveException e)
            {
                _ui.DisplayGeneralError(e.Message);
            }
        }
    }
}
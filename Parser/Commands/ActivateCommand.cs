namespace Exam
{
    using System;
    using System.Collections.Generic;

    public class ActivateCommand : ICommand
    {
        public ActivateCommand(IStregSystemUI ui, StregSystem stregSystem, Product product)
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
                 _stregSystem.ChangeActiveStatus(_product, true);
                 _ui.DisplayProductIsActive(_product);
                 Console.ReadLine();
             }
             catch (ProductNotActiveException e)
             {
                 _ui.DisplayGeneralError(e.Message);
             }
        }
    }
}
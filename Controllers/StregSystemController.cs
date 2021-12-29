using System;
using StregSystem.Model.StregSystem;
using StregSystem.Parser.Commands;
using StregSystem.UI;
namespace StregSystem.Controllers
{

    internal class StregSystemController
    {
        private IStregSystemUI _ui;
        private CommandFactory _commandFactory;
        public StregSystemController(IStregSystemUI ui, StregSystemModel stregSystem)
        {
            _ui = ui;
            _commandFactory = new CommandFactory(ui, stregSystem);
            _ui.CommandEntered += OnCommandEntered;
        }

        private void OnCommandEntered(object sender, string commandString)
        {
            try
            {
                ICommand command = _commandFactory.Parse(commandString);
                command.Execute();
            }
            catch (Exception e)
            {
                _ui.DisplayGeneralError(e.Message);
            }
        }
    }
}
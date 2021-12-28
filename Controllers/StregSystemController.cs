namespace Exam
{
    using System;

    internal class StregSystemController
    {
        private IStregSystemUI _ui;
        private CommandFactory _commandFactory;
        public StregSystemController(IStregSystemUI ui, StregSystem stregSystem)
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
                Console.WriteLine(command.ToString());
                command.Execute();
            }
            catch (Exception e)
            {
                _ui.DisplayGeneralError(e.Message);
            }
        }
    }
}
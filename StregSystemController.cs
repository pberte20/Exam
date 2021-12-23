namespace Exam
{
    using System;

    internal class StregSystemController
    {
        private IStregSystemUI _ui;
        public StregSystemController(IStregSystemUI ui, StregSystem stregSystem)
        {
            _ui = ui;
            _ui.CommandEntered += OnCommandEntered;
        }

        private void OnCommandEntered(object sender, string command)
        {
            string[] commandParts = command.Split(' ');
            switch (commandParts[0])
            {
                case "help":
                    _ui.DisplayGeneralError("Not implemented");
                    break;
                case "exit":
                    _ui.Close();
                    break;
                // case "insert":
                //     InsertCashTransaction(commandParts);
                //     break;
                // case "buy":
                //     BuyProductTransaction(commandParts);
                //     break;
                // case "user":
                //     UserCommand(commandParts);
                //     break;
                // case "product":
                //     ProductCommand(commandParts);
                //     break;
                // case "admin":
                //     AdminCommand(commandParts);
                //     break;
                // default:
                //     _ui.DisplayAdminCommandNotFoundMessage(commandParts[0]);
                //     break;
            }
        }
    }
}
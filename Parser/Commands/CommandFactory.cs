namespace Exam
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CommandFactory
    {   
        public CommandFactory(IStregSystemUI ui, StregSystem stregSystem)
        {
            _ui = ui;
            _stregSystem = stregSystem;
        }
        private IStregSystemUI _ui;
        private StregSystem _stregSystem;

        public ICommand Parse(string command)
        {
            IEnumerable<string> commandParts = command.Split(' ');
            string FirstCommand = commandParts.First();
            switch (FirstCommand)
            {
               case ":q" or ":quit":
                return new QuitCommand(_ui);

                default:
                return parseUserCommand(commandParts);
            }
            
        }
        private ICommand parseUserCommand(IEnumerable<string> commandParts)
        {
            string FirstCommand = commandParts.First();
           

        }
    }
}
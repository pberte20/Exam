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
            IList<string> Arguments = commandParts.Skip(1).ToList();
            switch (FirstCommand)
            {
                case ":q" or ":quit":
                    return new QuitCommand(_ui);
                case ":activate":
                    return  ParseActivateCommand(Arguments);
                case ":deactivate":
                    return ParseDeactivateCommand(Arguments);
                default:
                    return parseUserCommand(FirstCommand, Arguments);
                
            }
            
        }
        private ICommand parseUserCommand(string  FirstCommand, IList<string> Arguments )
        {
           
                User user = _stregSystem.GetUserByUserName(FirstCommand);
                int id = int.Parse(Arguments[0]);
                Product product = _stregSystem.GetProductById(id);
                if (Arguments.Count() == 1)
                {
                    return new BuyCommand(_ui, _stregSystem, user, product);
                }
                else if (Arguments.Count() == 2)
                {
                    int amount = int.Parse(Arguments[1]);
                    return new BuyCommand(_ui, _stregSystem, user, product, amount);
                }
                else
                {
                    throw new ArgumentException("Invalid number of arguments");
                }

        }
        private ICommand ParseActivateCommand(IList<string> Arguments)
        {
            if (Arguments.Count() == 1)
            {
                int id = int.Parse(Arguments[0]);
                Product product = _stregSystem.GetProductById(id);
                return new ActivateCommand(_ui, _stregSystem, product);
            }
            else
            {
                throw new ArgumentException("Invalid number of arguments");
            }
        }
        private ICommand ParseDeactivateCommand(IList<string> Arguments)
        {
            if (Arguments.Count() == 1)
            {
                int id = int.Parse(Arguments[0]);
                Product product = _stregSystem.GetProductById(id);
                return new DeactivateCommand(_ui, _stregSystem, product);
            }
            else
            {
                throw new ArgumentException("Invalid number of arguments");
            }
        }
    }
}
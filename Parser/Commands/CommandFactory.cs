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
            char FirstCommandFirstLetter = FirstCommand.First();
            IList<string> Arguments = commandParts.Skip(1).ToList();
            if (FirstCommandFirstLetter == char.Parse(":"))
            {
                switch (FirstCommand)
                {
                    case ":q" or ":quit":
                        return new QuitCommand(_ui);
                    case ":activate":
                        return  ParseActivateStatusCommand(Arguments, true);
                    case ":deactivate":
                        return ParseActivateStatusCommand(Arguments, false);
                    case ":crediton":
                        return ParseCreditStatusCommand(Arguments, true);
                    case ":creditoff":
                        return ParseCreditStatusCommand(Arguments, false);
                    case ":addcredit":
                        return ParseAddCreditCommand(Arguments);
                    default:
                        throw new ArgumentException("Invalid Admin command");
                    
                }
            }
            else
            {
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
        private ICommand ParseActivateStatusCommand(IList<string> Arguments, bool status)
        {
            if (Arguments.Count() == 1)
            {
                int id = int.Parse(Arguments[0]);
                Product product = _stregSystem.GetProductById(id);
                return new ActivateStatusCommand(_ui, _stregSystem, product, status);
            }
            else
            {
                throw new ArgumentException("Invalid number of arguments");
            }
        }
        private ICommand ParseCreditStatusCommand(IList<string> Arguments, bool status)
        {
            if (Arguments.Count() == 1)
            {
                int id = int.Parse(Arguments[0]);
                Product product = _stregSystem.GetProductById(id);
                return new CreditStatusCommand(_ui,_stregSystem, product, status);
            }
            else
            {
                throw new ArgumentException("Invalid number of arguments");
            }
        }
        private ICommand ParseAddCreditCommand(IList<string> Arguments)
        {
            if (Arguments.Count() == 2)
            {
                User user = _stregSystem.GetUserByUserName(Arguments[0]);
                int amount = int.Parse(Arguments[1]);
                return new AddCreditCommand(_ui, _stregSystem, user, amount);
            }
            else
            {
                throw new ArgumentException("Invalid number of arguments");
            }
        }
        
    }
}
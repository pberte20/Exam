namespace Exam
{
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
            }
            return null;
        }
    }
}
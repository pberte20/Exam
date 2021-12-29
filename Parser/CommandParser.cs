using StregSystem.Model.StregSystem;
using StregSystem.UI;

namespace StregSystem.Parser
{

    class CommandParser
    {
        public CommandParser(StregSystemModel stregSystem, IStregSystemUI ui)
        {
            _stregSystem = stregSystem;
            _ui = ui;
        }

        private StregSystemModel _stregSystem;
        private IStregSystemUI _ui;

    }
}
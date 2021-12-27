namespace Exam
{
    using System;

    class CommandParser
    {
        public CommandParser(StregSystem stregSystem, IStregSystemUI ui)
        {
            _stregSystem = stregSystem;
            _ui = ui;
        }

        private StregSystem _stregSystem;
        private IStregSystemUI _ui;

    }
}
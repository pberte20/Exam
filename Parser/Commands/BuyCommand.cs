namespace Exam
{
    public class BuyCommand : ICommand
    {
        private IStregSystemUI _ui;
        private StregSystem _stregSystem;
        private User _user;

        public BuyCommand(IStregSystemUI ui, StregSystem stregSystem, string Username)
        {
            _ui = ui;
            _stregSystem = stregSystem;
            
        }

        public void Execute()
        {

        }
    }
}
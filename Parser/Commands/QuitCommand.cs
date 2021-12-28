namespace Exam
{
    public class QuitCommand : ICommand
    {
        private IStregSystemUI _ui;
        public QuitCommand(IStregSystemUI ui)
        {
            _ui = ui;
        }
        public void Execute()
        { 
            _ui.Close();
        }
    }
}
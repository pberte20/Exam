using StregSystem.UI;
using StregSystem.Controllers;
using StregSystem.Model.StregSystem;

namespace Program
{

    class Program
    {
        static void Main(string[] args)
        {
            StregSystemModel stregSystem = new StregSystemModel();
            StregSystemCLI stregSystemCLI = new StregSystemCLI(stregSystem);
            StregSystemController controller = new StregSystemController(stregSystemCLI, stregSystem);
            stregSystemCLI.Start();
         }    
    }

}

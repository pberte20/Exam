namespace Exam
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            StregSystem stregSystem = new StregSystem();
            StregSystemCLI stregSystemCLI = new StregSystemCLI(stregSystem);
            StregSystemController controller = new StregSystemController(stregSystemCLI, stregSystem);
            stregSystemCLI.Start();
         }    
    }

}

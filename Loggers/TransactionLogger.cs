using System.IO;
using StregSystem.Model.Transactions;

namespace StregSystem.Loggers
{
    public class TransactionLogger
    {
        private static string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Transactions.txt");
        public TransactionLogger()
        {
            using (StreamWriter writer = File.CreateText(_filePath))
            {
                writer.WriteLine("Transaction Log");
            }
        }
        public void Log(BaseTransaction transaction)
        {
            using (StreamWriter writer = File.AppendText(_filePath))
            {
                writer.WriteLine(transaction.ToString());
            }
        }
    }
}
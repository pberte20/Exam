namespace Exam
{
    using System;
    public interface IStregSystemUI
    {
    void DisplayUserNotFound(User user);
    void DisplayProductNotFound(Product product);
    void DisplayUserInfo(User user);
    void DisplayTooManyArgumentsError(string command);
    void DisplayAdminCommandNotFoundMessage(string adminCommand);
    void DisplayUserBuysProduct(BuyProductTransaction transaction);
    void DisplayUserBuysProduct(int count, BuyProductTransaction transaction);
    void Close();
    void DisplayInsufficientCash(User user, Product product);
    void DisplayGeneralError(string errorString);
    void Start();
    event EventHandler<string> CommandEntered;
 
    }
}
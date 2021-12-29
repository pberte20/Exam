using System;
using StregSystem.Model.Products;
using StregSystem.Model.Transactions;
using StregSystem.Model.Users;

namespace StregSystem.UI
{
    public interface IStregSystemUI
    {
    void DisplayUserNotFound(User user);
    void DisplayProductNotFound(Product product);
    void DisplayUserInfo(User user);
    void DisplayTooManyArgumentsError(string command);
    void DisplayAdminCommandNotFoundMessage(string adminCommand);
    void DisplayUserBuysProduct(BuyProductTransaction transaction);
    void DisplayUserBuysProduct(int count, BuyProductTransaction transaction);
    void DisplayCashInserted(InsertCashTransaction transaction);
    void Close();
    void DisplayInsufficientCash(User user, Product product);
    void DisplayGeneralError(string errorString);
    void DisplayProductIsActive(Product product);
    void DisplayProductIsActiveChanged(Product product, bool isActive);
    void DisplayCreditStatusChanged(Product product, bool isActive);
    void Start();
    event EventHandler<string> CommandEntered;
 
    }
}
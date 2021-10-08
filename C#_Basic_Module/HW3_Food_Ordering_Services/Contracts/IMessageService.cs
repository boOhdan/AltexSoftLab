namespace FoodOrdering.BLL.Contracts
{
    public interface IMessageService
    {
        bool SendMessage(string message);
        string ReceiveMessage();
    }
}

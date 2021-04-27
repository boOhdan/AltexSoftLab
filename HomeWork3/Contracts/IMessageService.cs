namespace FoodOrdering
{
    public interface IMessageService
    {
        bool SendMessage(string message);
        string ReceiveMessage();
    }
}

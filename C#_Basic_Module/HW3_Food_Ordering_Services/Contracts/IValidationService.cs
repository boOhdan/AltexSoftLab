namespace FoodOrdering.BLL.Contracts
{
    public interface IValidationService
    {
        bool IsNumberValid(string number);
        bool IsAddressValid(string address);
    }
}

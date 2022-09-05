namespace aura_web_blazor.Services
{
    public interface IOrderService
    {
        Task<List<Data.Models.DetaletEFaturimit>>GetOrders();
    }
}

namespace EcommerceDBProject.Services.Interface
{
    public interface IOrderReturnReviewInterface
    {
        bool IsReturnAvailable(string orderItemId);
        bool IsReviewAvailable(string orderItemId);
    }
}

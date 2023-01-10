namespace OMS.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponce<List<Product>>> GetProducts();
        Task<ServiceResponce<List<Product>>> AddProduct(Product product);
        Task<ServiceResponce<List<Product>>> UpdateProduct(Product product);
        Task<ServiceResponce<List<Product>>> DeleteProduct(int productId);
    }
}

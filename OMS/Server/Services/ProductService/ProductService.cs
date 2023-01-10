using OMS.Shared;

namespace OMS.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext dataContext;

        public ProductService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<ServiceResponce<List<Product>>> AddProduct(Product product)
        {
            product.Editing = product.IsNew = false;
            dataContext.Products.Add(product);
            await dataContext.SaveChangesAsync();
            return await GetProducts();
        }

        public async Task<ServiceResponce<List<Product>>> DeleteProduct(int productId)
        {
            Product product = await dataContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (product == null)
            {
                return new ServiceResponce<List<Product>>
                {
                    Success = false,
                    Message = "Product not found."
                };
            }

            product.Deleted = true;
            dataContext.Remove(product);
            await dataContext.SaveChangesAsync();

            return await GetProducts();
        }

        public async Task<ServiceResponce<List<Product>>> GetProducts()
        {
            var response = new ServiceResponce<List<Product>>()
            {
                Data = await dataContext.Products.ToListAsync()               
            };

            if(response == null || response.Data == null)
            {
                response.Success = false;
                response.Message = "The program failed to fetch data from the server.";
            }

            return response;

        }

        public async Task<ServiceResponce<List<Product>>> UpdateProduct(Product product)
        {
            var dbProduct = await  dataContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (dbProduct == null)
            {
                return new ServiceResponce<List<Product>>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            dbProduct.Name = product.Name;
            dbProduct.Producer = product.Producer;

            await dataContext.SaveChangesAsync();

            return await GetProducts();
        }
    }
}

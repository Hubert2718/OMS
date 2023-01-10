using OMS.Client.Pages;
using OMS.Shared;
using static System.Net.WebRequestMethods;

namespace OMS.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public List<Product> Products { get; set; }

        public event Action ProductsChanged;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddProduct(Product product)
        {
            var response = await httpClient.PostAsJsonAsync("api/product", product);
            Products = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<Product>>>()).Data;
            ProductsChanged.Invoke();
        }

        public async Task DeleteProduct(int productId)
        {
            var response = await httpClient.DeleteAsync($"api/product/{productId}");
            Products = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<Product>>>()).Data;
            ProductsChanged.Invoke();
        }

        public async Task GetProducts()
        {
            var result =  await httpClient.GetFromJsonAsync<ServiceResponce<List<Product>>>("api/product");
            if (result != null && result.Data != null)
                Products = result.Data;

            ProductsChanged.Invoke();
        }

        public async Task UpdateProduct(Product product)
        {
            var response = await httpClient.PutAsJsonAsync("api/product/update", product);
            Products = (await response.Content.ReadFromJsonAsync<ServiceResponce<List<Product>>>()).Data;
            ProductsChanged.Invoke();
        }

        public Product CreateNewProduct()
        {
            var newProduct = new Product { IsNew = true, Editing = true };
            Products.Add(newProduct);
            ProductsChanged.Invoke();
            return newProduct;
        }
    }
}

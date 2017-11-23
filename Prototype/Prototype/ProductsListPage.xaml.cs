using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace Prototype
{
    public partial class ProductsListPage : ContentPage
    {
        DBService dBService = new DBService();



        ObservableCollection<ProductModel> Products = new ObservableCollection<ProductModel>();



        public ProductsListPage()
        {  
            Title = "Products";
            
            
            Products = new ObservableCollection<ProductModel>();

            //for (int i = 0; i < 40; i++)
            //{
            //    string path = "icon.png";
            //    string a = Convert.ToString(i);
            //    ProductModel product = new ProductModel { Name = "ProductPrice №:" + a, Category = "ProductCategory №:"+ a, Price = i + 100, ImagePath = path, Description = "Description: this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; " + a };
            //    ProductList.Add(product);
            //}
           
            
            InitializeComponent();
            Task getproducts = GetProducts();
            getproducts.Wait();
            ProductGrid.ItemsSource = Products;
            GridLayout.Children.Add(ProductGrid);
            this.Content = GridLayout;
            ProductGrid.ItemSelected += ProductGrid_ItemSelected;
            ProductGrid.ItemTapped += ProductGrid_ItemTapped;

        }

        private async void ProductGrid_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ProductModel product = e.Item as ProductModel;
            if (product != null)
            {
                await Navigation.PushAsync(new ProductPage(product));
            }
        }

        private void ProductGrid_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            ((ListView)sender).SelectedItem = null;

        }

        private void SearchProducts(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                ProductGrid.ItemsSource = Products.Where(u => u.Name.Contains(text));
            }
            else
            {
                ProductGrid.ItemsSource = Products;
            }
        }

        private async Task GetProducts()
        {

            IEnumerable<ProductModel> product = await dBService.Get();
            //while (Products.Any())
            //{
            //    Products.RemoveAt(Products.Count - 1);
            //}
            foreach (ProductModel p in product)
            {
                Products.Add(p);
            }
        }

    }
}


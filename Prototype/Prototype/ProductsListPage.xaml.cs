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

  
        public ObservableCollection<ProductModel> ProductList { get; set; }
        public ProductsListPage()
        {  
            Title = "Products";

            
            ProductList = new ObservableCollection<ProductModel>();

            for (int i = 0; i < 40; i++)
            {
                string path = "icon.png";
                string a = Convert.ToString(i);
                ProductModel product = new ProductModel { Name = "ProductPrice №:" + a, Category = "ProductCategory №:"+ a, Price = i + 100, ImagePath = path, Description = "Description: this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; this.Content = GridLayout; " + a };
                ProductList.Add(product);
            }
            InitializeComponent();
            ProductGrid.ItemsSource = ProductList;
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
                ProductGrid.ItemsSource = ProductList.Where(u => u.Name.Contains(text));
            }
            else
            {
                ProductGrid.ItemsSource = ProductList;
            }
        }

    }
}


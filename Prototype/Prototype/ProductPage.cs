using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prototype
{
    public class ProductPage : ContentPage
    {
   
        public ProductPage(ProductModel product)
        {
            Title = "Product";
            Content = new StackLayout
            {
                Children = {
                    new Image { Source = product.ImagePath },
                    new Label { Text = product.Name },
                    new Label { Text = product.Category },
                    new Label { Text = Convert.ToString(product.Price), FontSize = 22, TextColor = Color.Green  }

                }
            };
        }
    }
}
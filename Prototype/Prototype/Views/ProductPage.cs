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
            ScrollView ImageScroll = new ScrollView
            {  
                
                Orientation = ScrollOrientation.Horizontal,
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    WidthRequest = 1200,
                    Children = {
                     new Image { Source = product.ImagePath, HeightRequest = 400, WidthRequest = 400 },
                     new Image { Source = product.ImagePath, HeightRequest = 400, WidthRequest = 400 },
                     new Image { Source = product.ImagePath, HeightRequest = 400, WidthRequest = 400 }}
                }
            };

            StackLayout textLayout = new StackLayout
            {

                Children =
                {
                    new Label { Text = product.Name,FontSize = 22, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Start},
                    new Label { Text = product.Category, FontSize = 22,HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center },
                    new Label { Text = Convert.ToString(product.Price), FontSize = 22, TextColor = Color.Green,HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.End},
                    new Label { Text = product.Description, FontSize = 22, TextColor = Color.Green,HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.End}
                }
            };
            StackLayout layout = new StackLayout { Orientation = StackOrientation.Vertical };
            layout.Children.Add(ImageScroll);
            layout.Children.Add(textLayout); 

            this.Content = new ScrollView { Content = layout};

        }
    }
}
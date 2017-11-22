using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prototype
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedProductPage : ContentPage
    {
        public ProductModel product { get; private set; }

        public SelectedProductPage(ProductModel product)
        {
            Title = "Продукт";
            Button backButton = new Button
            {
                Text = "Назад",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };
            Image pic = new Image();
            Label Name = new Label { FontSize = 30, TextColor = Color.BlueViolet };
            Label Category = new Label { FontSize = 30, TextColor = Color.BlueViolet};
            Label Price = new Label { FontSize = 30, TextColor = Color.BlueViolet };
            InitializeComponent();
            this.product = product;
            StackLayout Image = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };
            StackLayout Details = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.End
            };

            StackLayout layout = new StackLayout();
  
            Details.Children.Add(Name);
            Details.Children.Add(Category);
            Details.Children.Add(Price);
            Image.Children.Add(pic);
            layout.Children.Add(Details);
            layout.Children.Add(Image);
            layout.Children.Add(backButton);

            Content = backButton;
            backButton.Clicked += BackButton_Clicked;


            Name.Text = product.Name;
            Category.Text = product.Category;
            Price.Text = Convert.ToString(product.Price);
            pic.Source = "icon.png";
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }



    }

}
    
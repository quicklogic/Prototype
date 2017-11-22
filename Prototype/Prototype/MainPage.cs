using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Prototype
{
    public class MainPage : ContentPage
    {
        static MasterDetailPage MDPage;
        public static Page GetMainPage()
        {
            return MDPage = new MasterDetailPage
            {
                Master = new ContentPage
                {
                    Title = "Master",
                    BackgroundColor = Color.Silver,
                    Icon = Device.OS == TargetPlatform.Android ? "menu.png" : null,
                    Content = new StackLayout
                    {
                        Padding = new Thickness(5, 50),
                        Children = { Link("Products"), Link("B"), Link("C") }
                    },
                },
                Detail = new NavigationPage(new ProductsListPage()),
            };
        }

        static Button Link(string name)
        {
            var button = new Button
            {
                Text = name,
                BackgroundColor = Color.FromRgb(0.9, 0.9, 0.9)
            };
            button.Clicked += delegate {
                MDPage.Detail = new NavigationPage(new ContentPage
                {
                    Title = name,
                    Content = new Label { Text = name }
                });
                MDPage.IsPresented = false;
            };
            return button;
        }
    }
}
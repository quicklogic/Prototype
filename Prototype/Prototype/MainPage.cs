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
            var toolbarItem = new ToolbarItem
            {
                 Text = "+", 
                 Icon = Device.RuntimePlatform == Device.Android ? null : "search.png"
             };

       

            return MDPage = new MasterDetailPage
            {
                 
                Master = new ContentPage
                {
                  
                    Title = "Master",
                    BackgroundColor = Color.Silver,
                    Icon = Device.RuntimePlatform == Device.Android ? "menu.png" : null,
                    Content = new StackLayout
                    {   
                        Padding = new Thickness(5, 50),
                        Children = { Link("Main page",new ProductsListPage()), Link("User Profile", new UserProfilePage()), Link("Settings", new ProductsListPage()) },
                        
                    },
                },
                Detail = new NavigationPage(new ProductsListPage()),
            };
        }

        static Button Link(string name, ContentPage page)
        {
            var button = new Button
            {
                Text = name,
                BackgroundColor = Color.FromRgb(0.9, 0.9, 0.9)
            };
            button.Clicked += delegate {
                MDPage.Detail = new NavigationPage(page);
                MDPage.IsPresented = false;
            };
            return button;
        }
    }
}
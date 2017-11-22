using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prototype
{
    public delegate void SearchEventHandler(string text);
    class SearchView : ContentView
    {
        public event SearchEventHandler Search;
        public SearchView()
        {
            Color color = Color.FromHex("#26A69A");
            Button searchBtn = new Button { Text = "Найти"};
            Entry searchEntry = new Entry
            {     
                HorizontalOptions = LayoutOptions.FillAndExpand,
                
            };
            
            searchBtn.Clicked += (sender, e) => Search?.Invoke(searchEntry.Text);
            Content = new StackLayout
            {
              
                Orientation = StackOrientation.Horizontal,
                Spacing = 5,
                Padding = 3,
                Children =
                {
                    searchEntry,
                    searchBtn
                }
            };
        }

    }
}

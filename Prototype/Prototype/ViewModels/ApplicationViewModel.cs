using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prototype.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        bool initialize = false;
        ProductModel selectedProduct;
        private bool isBusy;

        public ObservableCollection<ProductModel> Products { get; set; }
        DBService dBService = new DBService();
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand BackCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");

            }
        }

        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public ApplicationViewModel()
        {
            Products = new ObservableCollection<ProductModel>();
            IsBusy = false;
            BackCommand = new Command(Back);
        }

        public ProductModel SelectedItem
        {
            get { return selectedProduct; }
            set
            {
                if (selectedProduct != null)
                {
                    ProductModel tempProduct = new ProductModel()
                    {
                        ID = value.ID,
                        Name = value.Name,
                        Category = value.Category,
                        Description = value.Description,
                        Price = value.Price,
                        Type = value.Type,
                        ImagePath = "icon.png"
                    }; 
                }
            }
                    
        }

        private async void Back()
        {
            await Navigation.PopAsync();
        }
        
        public async Task<ObservableCollection<ProductModel>> GetProducts()
        {
            IsBusy = true;
            IEnumerable<ProductModel> product = await dBService.Get();
            while (Products.Any())
                Products.RemoveAt(Products.Count - 1);

            foreach (ProductModel p in Products)
                Products.Add(p);
            IsBusy = false;
            initialize = true;

            return Products;
        }

    }
}

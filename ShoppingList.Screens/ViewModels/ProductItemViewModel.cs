using ShoppingList.Domain.Entities;
using ShoppingList.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Screens.ViewModels
{
    public class ProductItemViewModel : ViewModelBase
    {
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set 
            { 
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private DateTime _registrationData;
        public DateTime RegistrationData
        {
            get { return _registrationData; }
            set 
            { 
                _registrationData = value;
                OnPropertyChanged(nameof(RegistrationData));
            }
        }

        public ProductItemViewModel()
        {

        }

        public ProductItemViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            RegistrationData = product.RegistrationData;
        }



    }
}

using Microsoft.Toolkit.Mvvm.ComponentModel;
using ShoppingList.Domain.Entities;
using ShoppingList.Service.Events;
using System;

namespace ShoppingList.Service.ViewModels
{
    public class ProductItemViewModel : ObservableObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                SetProperty(ref _id, value);
            }
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                SetProperty(ref _name, value);

            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set 
            {
                SetProperty(ref _description, value);
            }
        }

        private DateTime _registrationData;
        public DateTime RegistrationData
        {
            get { return _registrationData; }
            set 
            { 
                SetProperty(ref _registrationData, value);

            }
        }

        private bool _isEnable;
        public bool IsEnable
        {
            get  
            {
                return _isEnable;
            }
            set 
            {
                SetProperty(ref _isEnable, value);
            }
        }

        public ProductItemViewModel() { }

        public ProductItemViewModel(int id, string name, string description, DateTime registrationData) 
        {
            Id = id;
            Name = name;
            Description = description;
            RegistrationData = registrationData;
        }
        
        public static ProductItemViewModel Create(Product product)
        {
            var productItemViewModel = new ProductItemViewModel(

                product.Id,
                product.Name,
                product.Description,
                product.RegistrationData

            );

            return productItemViewModel;
        }

        public Product ForProduct()
        {
            var productItemViewModel = new Product
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                RegistrationData = this.RegistrationData
            };

            return productItemViewModel;
        }

        public void Update()
        {
            ShoppingListEvents.OnUpdateProduct(ForProduct());
        }

        public void Delete()
        {
            ShoppingListEvents.OnDeleteProduct(ForProduct());
        }

        public void Add()
        {
            try
            {
                ShoppingListEvents.OnAddProduct(ForProduct());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}

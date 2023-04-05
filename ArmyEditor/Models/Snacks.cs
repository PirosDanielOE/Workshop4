using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyEditor.Models
{
    public class Snacks : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        public Snacks GetCopy()
        {
            return new Snacks()
            {
                Name = this.Name,
                Price = this.Price,
                Quantity = this.Quantity,
            };
        }


    }
}

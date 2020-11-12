using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Location
    {
        private List<Product> _productlist = new List<Product>();
        private string _locationname;

        public List<Product> ProductList { get => _productlist; private set => _productlist = value; }
        public string LocationName { get => _locationname; private set => _locationname = value; }

        public Location(string locationName)
        {
            LocationName = locationName;
        }





    }
}

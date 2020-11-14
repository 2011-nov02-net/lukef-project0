using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace StoreApplication.ClassLibrary.StoreApplication.Design
{
    public class Application : IApp
    {
        private List<Location> _locationlist = new List<Location>();
        public List<Location> LocationList { get => _locationlist; private set => _locationlist = value; }

        private List<Order> _orderlist = new List<Order>();
        public  List<Order> OrderList { get => _orderlist; private set => _orderlist = value; }

        private List<Customer> _customerlist = new List<Customer>();
        public  List<Customer> CustomerList { get => _customerlist; private set => _customerlist = value; }

        

        void IApp.AddCustomer(Customer customer)
        {
            if (!_customerlist.Contains(customer))
            {
                _customerlist.Add(customer);
            }
        }

        void IApp.AddOrder(Order order)
        {
            if (!_customerlist.Contains(order.customer))
            {
                throw new ArgumentException("That customer is not in our files!");
            }
            if (!_locationlist.Contains(order.location))
            {
                throw new ArgumentException("That location is not in our files!");
            }
            
            
            
        }

        void IApp.PrintStoreOrderHistory()
        {
            

        }

        void IApp.SearchCustomerByName()
        {

        }

        void IApp.SerializeData(Type datatype, object data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(datatype);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            TextWriter writer = new StreamWriter(filePath);
            xmlSerializer.Serialize(writer, data);
            writer.Close();
        }

        void IApp.DeserializeData(Type datatype, string filePath)
        {
            object o = null;

            XmlSerializer xmlSerializer = new XmlSerializer(datatype);
            if(File.Exists(filePath))
            {
                TextReader reader = new StreamReader(filePath);
                o = xmlSerializer.Deserialize(reader);
                reader.Close();
            }

            

        }


    }
}

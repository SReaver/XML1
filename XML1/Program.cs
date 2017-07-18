using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XML1
{
    public class Order
    {public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> Count { get; set; }
        public string Brand { get; set; }
        public string Article { get; set; }
        public string Name { get; set; }
       
        public Nullable<int> Price { get; set; }
        public string ShipmentPeriod { get; set; }
        public string Warehouse { get; set; }

       
    }


    class Program
    {
        static void CreateXml(Order order)
        {
            XDocument xdoc = new XDocument();
            XElement ordersRoot = new XElement("orders");
            XElement xmlOrders = new XElement("order");

            XAttribute orderAttr = new XAttribute("Id", 161);
            XAttribute orderElem_UserId = new XAttribute("Elem1", 145);

            xmlOrders.Add(orderAttr);
            xmlOrders.Add(orderElem_UserId);

            ordersRoot.Add(xmlOrders);
            xdoc.Add(ordersRoot);
            xdoc.Save("orders.xml");
        }
        static void Main(string[] args)
        {
            
            List<Order> orders = new List<Order>();
            orders.Add(new Order() { UserId=123, Count=3, Brand="Silica", Article="Visio", Name="Titev", Price=23, ShipmentPeriod="34", Warehouse="Lublino", Id=45});
            orders.Add(new Order() { UserId = 122, Count = 2, Brand = "Teren", Article = "Fimin", Name = "Titev", Price = 230, ShipmentPeriod = "3", Warehouse = "Afiro", Id = 33 });
            orders.Add(new Order() { UserId = 121, Count = 5, Brand = "Zeo", Article = "Gaze", Name = "Titev", Price = 56, ShipmentPeriod = "56", Warehouse = "Cintro", Id = 89 });

            CreateXml(new Order() { UserId = 123, Count = 3, Brand = "Silica", Article = "Visio", Name = "Titev", Price = 23, ShipmentPeriod = "34", Warehouse = "Lublino", Id = 45 });

        }
    }
}

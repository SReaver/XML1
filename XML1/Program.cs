using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public void SetXML()
        { }

       
    }


    class Program
    {
        static void CreateXml(Order order)
        {
            XDocument xdoc = new XDocument();
            XElement ordersRoot = new XElement("orders");
            XElement xmlOrders = new XElement("order");

            XAttribute orderAttr = new XAttribute("Id", 161);
            XElement orderElem_UserId = new XElement("Elem1", 145);

            xmlOrders.Add(orderAttr);
            xmlOrders.Add(orderElem_UserId);

            ordersRoot.Add(xmlOrders);
            xdoc.Add(ordersRoot);
            xdoc.Save("orders.xml");
        }

        //C:\Users\плотниковс\Documents\Visual Studio 2015\Projects\FS2\FS2


        static void Main(string[] args)
        {
            
            List<Order> orders = new List<Order>();
            orders.Add(new Order() { UserId=123, Count=3, Brand="Silica", Article="Visio", Name="Titev", Price=23, ShipmentPeriod="34", Warehouse="Lublino", Id=45});
            orders.Add(new Order() { UserId = 122, Count = 2, Brand = "Teren", Article = "Fimin", Name = "Titev", Price = 230, ShipmentPeriod = "3", Warehouse = "Afiro", Id = 33 });
            orders.Add(new Order() { UserId = 121, Count = 5, Brand = "Zeo", Article = "Gaze", Name = "Titev", Price = 56, ShipmentPeriod = "56", Warehouse = "Cintro", Id = 89 });

            Order o = new Order() { UserId = 123, Count = 3, Brand = "Silica", Article = "Visio", Name = "Titev", Price = 23, ShipmentPeriod = "34", Warehouse = "Lublino", Id = 45 };
            CreateXml(o);



            XDocument xd1 = new XDocument();

            XElement xmlOrders = new XElement("orders");
            foreach (var item in orders)
            {
                XElement newXElem = new XElement("order");


                PropertyInfo[] pInfo = typeof(Order).GetProperties();
                MethodInfo[] mInfo = typeof(Order).GetMethods();
                for (int i = 0; i < pInfo.Length; i++)
                {
                    XElement orderElem = new XElement(pInfo[i].Name, item.GetType().GetProperty(pInfo[i].Name).GetValue(item, null));
                    newXElem.Add(orderElem);
                    XElement orderMethod = new XElement(mInfo[i].Name, item.GetType().GetMethod(mInfo[i].Name));
                    newXElem.Add(orderMethod);
                }
                xmlOrders.Add(newXElem);

                //MethodInfo[] minfo = typeof(Order).GetMethods();
                //for (int i = 0; i < mInfo.Length; i++)
                //{
                //    XElement orderElem = new XElement(pInfo[i].Name, item.GetType().GetProperty(pInfo[i].Name).GetValue(item, null));
                //    XElement orderMethod = new XElement(mInfo[i]., item.GetType().GetMethod(pInfo[i].Name));

                //    newXElem.Add(orderElem);
                //    newXElem.Add(orderMethod);
                //}
                //xmlOrders.Add(newXElem);


            }
            xd1.Add(xmlOrders);
            xd1.Save("newXml.xml");





        }
    }
}

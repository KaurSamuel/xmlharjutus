using System;
using System.Xml;

namespace XML_ülesanne
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("1.Loo uus märge");
                Console.WriteLine("2.Loe olemasolevaid märkmeid");
                int valik = int.Parse(Console.ReadLine());
                if (valik == 1)
                {
                    Kirjutaja();
                }
                else if (valik == 2)
                {
                    Lugeja();
                }
                else
                {
                    Console.WriteLine("Do you even numbers?");
                }
            }
           
        }


        static void Lugeja()
        {
            Console.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../Notes.xml");
            foreach (XmlNode xmlnode in xmlDoc.DocumentElement.ChildNodes)
            {
                Console.WriteLine(xmlnode.Attributes["Pealkiri"].Value+ ": ");
                Console.WriteLine(xmlnode.Attributes["Sisu"].Value);
                Console.WriteLine();
            }



            //XmlReader xmlreader = XmlReader.Create("../../Notes.xml");
            //while (xmlreader.Read())
            //{
            //    if ((xmlreader.NodeType == XmlNodeType.Element) &&
            //        (xmlreader.Name == "Notes"))
            //    {
            //            Console.WriteLine(xmlreader.GetAttribute("Pealkiri")+
            //                ": "+xmlreader.GetAttribute("Sisu"));
            //    }
            //}
            Console.ReadKey();
        }


        static void Kirjutaja()
        {
            Console.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../Notes.xml");
            XmlNode rootnode = xmlDoc.SelectSingleNode("Notes");
            XmlNode markmed = xmlDoc.CreateElement("Note");
            XmlAttribute attribute1 = xmlDoc.CreateAttribute("Pealkiri");
            XmlAttribute attribute2 = xmlDoc.CreateAttribute("Sisu");
            Console.WriteLine("Palun sisestage uue märkme pealkiri.");
            attribute1.Value = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Palun sisestage märkme sisu.");
            attribute2.Value = Console.ReadLine();
            markmed.Attributes.Append(attribute1);
            markmed.Attributes.Append(attribute2);
            rootnode.AppendChild(markmed);
            xmlDoc.Save("../../Notes.xml");
            




            //XmlNode Pealkiri = xmlDoc.CreateElement("Pealkiri");
            //XmlNode Sisu = xmlDoc.CreateElement("Sisu");
            //Sisu.InnerText = Console.ReadLine();
            //Pealkiri.AppendChild(Sisu);
            //xmlDoc.DocumentElement.AppendChild(Pealkiri);
            //xmlDoc.Save("../../Notes2.xml");
        }
    }
}

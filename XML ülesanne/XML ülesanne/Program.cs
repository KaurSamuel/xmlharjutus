using System;
using System.Threading;
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
                Console.WriteLine("3. Modifitseeri märkmeid");
                string valik = Console.ReadLine();
                if (valik == "1")
                {
                    Kirjutaja();
                }
                else if (valik == "2")
                {
                    Lugeja();
                }
                else if (valik=="3")
                {
                    Modifitseeri();
                }
                else
                {
                    Console.WriteLine("Do you even numbers?");
                    Thread.Sleep(400);
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
                Console.WriteLine("("+xmlnode.Attributes["Aeg"].Value + ") "+xmlnode.Attributes["Pealkiri"].Value+ ": ");
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
            XmlAttribute aeg = xmlDoc.CreateAttribute("Aeg");
            aeg.Value = DateTime.Now.ToString();
            Console.WriteLine("Palun sisestage uue märkme pealkiri.");
            attribute1.Value = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Palun sisestage märkme sisu.");
            attribute2.Value = Console.ReadLine();
            markmed.Attributes.Append(attribute1);
            markmed.Attributes.Append(attribute2);
            markmed.Attributes.Append(aeg);
            rootnode.AppendChild(markmed);
            xmlDoc.Save("../../Notes.xml");
            




            //XmlNode Pealkiri = xmlDoc.CreateElement("Pealkiri");
            //XmlNode Sisu = xmlDoc.CreateElement("Sisu");
            //Sisu.InnerText = Console.ReadLine();
            //Pealkiri.AppendChild(Sisu);
            //xmlDoc.DocumentElement.AppendChild(Pealkiri);
            //xmlDoc.Save("../../Notes2.xml");
        }


        static int Modifitseeri()
        {
            Console.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../Notes.xml");

            Console.WriteLine("Kas tahate märget kustudada või muuta(k/m)");
            string valik2 = Console.ReadLine();
            if (valik2 == "m")
            {
                
                int Count = 1;
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    Console.WriteLine(Count + ". " + node.Attributes["Pealkiri"].Value);
                    Count += 1;
                }
                Console.WriteLine("Palun kirjutage märkme pealkiri mida te tahate modifitseerida.");
                string valik = Console.ReadLine();
                Console.Clear();
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    if (node.Attributes["Pealkiri"].Value == valik)
                    {
                        Console.WriteLine("Praegune märkme sisu: ");
                        Console.WriteLine(node.Attributes["Sisu"].Value);
                        Console.WriteLine("Uus märkme sisu: ");
                        string uus_sisu = Console.ReadLine();
                        node.Attributes["Sisu"].Value = uus_sisu;
                        Console.WriteLine("Märge on muudetud!");
                        xmlDoc.Save("../../Notes.xml");
                        Console.ReadLine();
                        return (0);
                    }
                }
                Console.WriteLine("Ühtegi sellise nimega märget ei leidud!");
                Console.ReadLine();
                return (0);
            }
            else if (valik2 == "k")
            {
                int Count = 1;
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    Console.WriteLine(Count + ". " + node.Attributes["Pealkiri"].Value);
                    Count += 1;
                }
                Console.WriteLine("Palun kirjutage märkme pealkiri mida te tahate kustutada.");
                string valik = Console.ReadLine();
                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    if (node.Attributes["Pealkiri"].Value == valik)
                    {
                        Console.WriteLine("oled kindel?(y/n)");
                        string y_n = Console.ReadLine();
                        if (y_n == "y")
                        {
                            node.ParentNode.RemoveChild(node);
                        }
                        else
                        {
                        }
                    }
                }
                xmlDoc.Save("../../Notes.xml");
            }
            else
            {
                Console.WriteLine("You are a bit special arent you?");
                Console.ReadLine();
            }
            return (0);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderSubmiter
{
    class ProductFactory
    {
        public ProductFactory()
        {

        }

        public ArrayList getItems(dynamic products)
        {
            ArrayList items = new ArrayList();
            foreach (var product in products)
            {
                ListBoxItem listItem = new ListBoxItem();
                listItem.Content = product.name;
                listItem.Height = 30;
                listItem.HorizontalAlignment = HorizontalAlignment.Left;
                //listItem.VerticalAlignment = VerticalAlignment.Top;
                //listBox.Margin = new Thickness(50, 150, 0, 0);

                items.Add(listItem);
            }


            ArrayList boi = new ArrayList();

            ListBoxItem listBoi = new ListBoxItem();
            listBoi.Content = "BOI";
            boi.Add(listBoi);

            return items;
        }
    }
}

using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace OrderSubmiter
{
    /// <summary>
    /// Populates the Main StackPanel with UIElements based off of 
    /// the json object recieved from Fetcher
    /// </summary>
    class ProductFactory
    {
        /// <summary>
        /// preset string template to display product Ids
        /// </summary>
        private string idLine = "Product ID: {0}";

        /// <summary>
        /// preset string template to display product descriptions
        /// </summary>
        private string descLine = "Description: {0}";

        /// <summary>
        /// creates an ArrayList of UIElements to be displayed in the main StackPanel
        /// for every product it makes a border, StackPanel, textBlock, and Button
        /// TODO:
        ///     insert image on far left of row
        /// </summary>
        /// <param name="products">Json object describing all products</param>
        /// <returns>ArrayList of UIElements to be displayed in the main StackPanel</returns>
        public ArrayList getItems(dynamic products)
        {
            ArrayList items = new ArrayList();
            foreach (var product in (dynamic)products)
            {
                ///create the boarder for each row
                Border border = new Border();
                border.BorderThickness = new Thickness(2,0,2,2);
                border.BorderBrush = Brushes.LightGray;

                ///create the stackPanel that holds the row
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;

                ///add text that desccripes the given product
                TextBlock text = new TextBlock();
                text.Width = 250;
                text.TextWrapping = TextWrapping.Wrap;
                text.Inlines.Add(product.name.ToString());
                text.Inlines.Add(new LineBreak());
                text.Inlines.Add(string.Format(idLine, product.productID));
                text.Inlines.Add(new LineBreak());
                if (product.description.ToString().Length > 0)
                {
                    text.Inlines.Add(string.Format(descLine, product.description));
                    text.Inlines.Add(new LineBreak());
                }

                ///add button that starts an order
                OrderButton orderButton = new OrderButton();
                orderButton.product = product;
                orderButton.Click += new RoutedEventHandler(MainWindow.makeOrder);
                orderButton.Height = 35;
                orderButton.Content = "Start Order";
                
                panel.Children.Add(text);
                panel.Children.Add(orderButton);
                border.Child = panel;
                items.Add(border);
            }
            return items;
        }
    }
}

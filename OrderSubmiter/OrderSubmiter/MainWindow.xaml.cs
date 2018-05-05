using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace OrderSubmiter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// handles interactions with API, fetches and delivers information
        /// </summary>
        private static Fetcher fetch;

        /// <summary>
        /// creates UIElements in main StackPanel
        /// </summary>
        private ProductFactory factory = new ProductFactory();
        
        /// <summary>
        /// Inits the main window
        /// Populates the main scrollview with products
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            fetch = new Fetcher();
            refresh(null, null);
        }

        /// <summary>
        /// refreshes main scroll view of products
        /// TODO:
        ///     use this + Product factory to implement search
        /// </summary>
        /// <param name="sender">UIElement that called this method - Always refresh button</param>
        /// <param name="e">Not Used</param>
        private void refresh(object sender, RoutedEventArgs e)
        {
            dynamic prods = fetch.getProducts();
            var itemPanels = factory.getItems(prods);
            foreach (UIElement item in itemPanels)
            {
                this.productHolder.Children.Add(item);
            }
        }
        
        /// <summary>
        /// This method ensures that only valid numbers are entered into the QuatntBox
        /// TODO:
        ///     fix rounding down to nearest interval
        /// </summary>
        /// <param name="sender">The associated QuantBox</param>
        /// <param name="e">Not used</param>
        private static void QuantityBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            QuantBox box = (QuantBox)sender;
            ///finds non allowed text -- non numerical characters
            ///maybe need to refactor this
            Regex regEx = new Regex("[^0-9.-]+");
            if (!regEx.IsMatch(box.Text) && box.Text != "")
            {
                double val;
                if (box.interval != 0)
                {
                    ///This is supposed to round the value down to the nearest interval.
                    val = box.interval * (int)(Convert.ToDouble(box.Text) / box.interval);
                }
                else
                {
                    val = (int)Convert.ToDouble(box.Text);
                }
                box.Text = val.ToString();
            }
            else
            {
                box.Text = "";
            }
        }

        /// <summary>
        /// Creates an order based off of the associated product 
        /// and the value in the associated QuantBox
        /// TODO:
        ///     Fix sending orders outside the range ove the min/max and not on an interval
        /// </summary>
        /// <param name="sender">Send Order button associated with a product to order</param>
        /// <param name="e"></param>
        private static void SendOrderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderButton button = (OrderButton)sender;
            Order order = new Order(button.product, button.quantBox.getQuant());
            fetch.orderProduct(order, button);
        }

        /// <summary>
        /// Creates new UIElements when a Start order button is pushed for
        /// the product associated with the button pushed
        /// TODO:
        ///     implement price textbox
        ///         Calculate price based on price of product and QuantBox input
        /// </summary>
        /// <param name="sender">Order button that was pushed</param>
        /// <param name="e"></param>
        internal static void makeOrder(object sender, EventArgs e)
        {
            OrderButton button = (OrderButton)sender;
            ///create the container - holds and organizes everything in the row
            StackPanel container = (StackPanel)button.Parent;

            ///displays info about ordering. min / max quantity, etc 
            TextBlock orderInfo = new TextBlock();
            orderInfo.Margin = new Thickness(20, 0, 0, 0);
            
            ///labels for the quantity textbox and yet to be implemented price textBlock
            TextBlock priceQuantity = new TextBlock();
            priceQuantity.Inlines.Add("Enter Order Quantity:");
            priceQuantity.Inlines.Add(new LineBreak());
            priceQuantity.Inlines.Add("Price:");
            priceQuantity.Margin = new Thickness(20, 0, 0, 0);

            ///where user inputs teh number of an item they want to buy
            QuantBox quantityBox = new QuantBox();
            quantityBox.Height = 20;
            quantityBox.Width = 100;
            quantityBox.VerticalAlignment = VerticalAlignment.Top;
            quantityBox.Margin = new Thickness(20, 0, 0, 0);
            quantityBox.TextChanged += QuantityBox_TextChanged;

            ///sets the mmin, max, and quantity increment
            if (button.product.quantityMinimum != null)
            {
                quantityBox.min = (int)button.product.quantityMinimum;
                orderInfo.Inlines.Add(string.Format("Minimum Order :{0}", button.product.quantityMinimum.ToString()));
                orderInfo.Inlines.Add(new LineBreak());
            }
            if(button.product.quantityMaximum != null)
            {
                quantityBox.max = (int)button.product.quantityMaximum;
                orderInfo.Inlines.Add(string.Format("Maximum Order :{0}", button.product.quantityMaximum.ToString()));
                orderInfo.Inlines.Add(new LineBreak());
            }
            if (button.product.quantityIncrement != null)
            {
                orderInfo.Inlines.Add(string.Format("Quantity Increment :{0}", button.product.quantityIncrement.ToString()));
            }
            
            ///create the send order button
            OrderButton sendOrderButton = new OrderButton();
            sendOrderButton.quantBox = quantityBox;
            sendOrderButton.product = button.product;
            sendOrderButton.Margin = new Thickness(20, 0, 0, 0);
            sendOrderButton.Content = "Send Order";
            sendOrderButton.Click += SendOrderButton_Click;

            ///add created elements to containerB
            container.Children.Add(orderInfo);
            container.Children.Add(priceQuantity);
            container.Children.Add(quantityBox);
            container.Children.Add(sendOrderButton);
        }
    }
}

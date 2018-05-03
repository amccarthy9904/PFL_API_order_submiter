using System;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderSubmiter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread orderThread;
        private Fetcher fetch;
        private ProductFactory factory = new ProductFactory();
         
        public MainWindow()
        {
            InitializeComponent();
            this.fetch = new Fetcher();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dynamic prods = fetch.getProducts();
            var prodItems = factory.getItems(prods);
            foreach (UIElement item in prodItems)
            {
                this.productHolder.Children.Add(item);
            }
        }

        protected void textBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void scrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}

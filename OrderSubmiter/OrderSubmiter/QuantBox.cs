namespace OrderSubmiter
{
    class QuantBox : System.Windows.Controls.TextBox
    {
        /// <summary>
        /// Used for autocorrecting input to proper intervals
        /// TODO:
        ///     implement this
        /// </summary>
        public int interval;

        /// <summary>
        /// max order quantity
        /// </summary>
        public int max;

        /// <summary>
        /// minimum order quantity
        /// </summary>
        public int min;

        /// <summary>
        /// price of the product associated
        /// TODO:
        ///     implement
        /// </summary>
        public double price;

        /// <summary>
        /// Box beneath that displays price of quantity entered
        /// TODO:
        ///     implement
        /// </summary>
        public PriceBox priceBox;

        /// <summary>
        /// gets the text in the box converted to an int
        /// </summary>
        /// <returns>The int in the text box. Defaut to 1 if there is no input</returns>
        public int getQuant()
        {
            if (this.Text != "")
            {
                return System.Convert.ToInt32(this.Text);
            }
            return 1;
        }
    }

    class PriceBox : System.Windows.Controls.TextBox
    {
        /// <summary>
        /// price of the product associated with the PriceBox
        /// </summary>
        public int prodPrice;
    }
}

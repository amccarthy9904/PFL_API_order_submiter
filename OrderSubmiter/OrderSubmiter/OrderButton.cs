namespace OrderSubmiter
{   
    /// <summary>
    /// button used to open the order menu and to send an order
    /// </summary>
    class OrderButton : System.Windows.Controls.Button
    {
        /// <summary>
        /// json description of product to order
        /// </summary>
        public dynamic product { get; set; }

        /// <summary>
        /// associated quantity box
        /// </summary>
        public QuantBox quantBox { get; set; }

        /// <summary>
        /// creates and returns an OrderButton and sets height to 35
        /// </summary>
        public OrderButton()
        {
            this.Height = 35;
        }
    }
}

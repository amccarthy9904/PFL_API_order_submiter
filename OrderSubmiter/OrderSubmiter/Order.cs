using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OrderSubmiter
{
    /// <summary>
    /// class used to mimic the structure of the jason objects defined in the API documentation
    /// built to be serialized into json
    /// 
    /// TODO:
    ///     add payments
    ///     add itemShipments
    ///     add webhooks
    ///     add billingVariables
    ///     add multiple items
    ///     add multiple shipments
    /// </summary>
    class Order
    {
        /// <summary>
        /// need at the begining of every orde
        /// </summary>
        public string partnerOrderReference = "MyReferenceNumber";

        /// <summary>
        /// info about customer
        /// </summary>
        public customerData orderCustomer;

        /// <summary>
        /// list of items to be ordered
        /// </summary>
        public ArrayList items;

        /// <summary>
        /// list of shipments to make
        /// </summary>
        public ArrayList shipments;

        /// <summary>
        /// creates an order object that will serialize into json
        /// uses the same shipping and customer data every time
        /// </summary>
        /// <param name="product">the product to be ordered</param>
        /// <param name="quant">the number of the product to be ordered</param>
        public Order(dynamic product, int quant)
        {
            orderCustomer = new customerData();
            orderCustomer.firstName = "John";
            orderCustomer.lastName = "Doe";
            orderCustomer.companyName = "ACME";
            orderCustomer.address1 = "1 Acme Way";
            orderCustomer.address2 = " ";
            orderCustomer.city = "Livingston";
            orderCustomer.state = "MT";
            orderCustomer.postalCode = "59047";
            orderCustomer.countryCode = "US";
            orderCustomer.email = "jdoe@acme.com";
            orderCustomer.phone = "1234567890";

            ProductData prodData = new ProductData();
            prodData.productID = product.productID;
            prodData.itemSequenceNumber = 1;
            prodData.quantity = quant;

            ShipmentData shipData = new ShipmentData();
            shipData.firstName = orderCustomer.firstName;
            shipData.lastName = orderCustomer.lastName;
            shipData.companyName = orderCustomer.companyName;
            shipData.address1 = orderCustomer.address1;
            shipData.address2 = orderCustomer.address2;
            shipData.city = orderCustomer.city;
            shipData.postalCode = orderCustomer.postalCode;
            shipData.countryCode = orderCustomer.countryCode;
            shipData.postalCode = orderCustomer.phone;
            shipData.shippingMethod = product.shippingMethodDefault;


            this.items = new ArrayList();
            this.shipments = new ArrayList();
            this.items.Add(prodData);
            this.shipments.Add(shipData);
        }
    }

    /// <summary>
    /// mimics the orderCustomer section in the json required by the API
    /// </summary>
    class customerData
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string countryCode { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    /// <summary>
    /// mimics the productData section in the json required by the API
    /// </summary>
    class ProductData
    {
        public int itemSequenceNumber { get; set; }
        public int productID { get; set; }
        public int quantity { get; set; }
        public string partnerItemReference = "MyItemReferenceID";
        public string itemFile = "http://www.yourdomain.com/files/printReadyArtwork1.pdf";
    }

    /// <summary>
    /// mimics the shipmentData section in the json required by the API
    /// </summary>
    class ShipmentData
    {
        public int shipmentSequenceNumber = 1;
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string companyName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string countryCode { get; set; }
        public string phone { get; set; }
        public string shippingMethod { get; set; }
        public string IMBSerialNumber { get; set; }
    }

    /// <summary>
    /// mimics the payments section in the json required by the API
    /// TODO:
    ///     implement
    /// </summary>
    class Payments
    {

    }

    /// <summary>
    /// mimics the itemShipments section in the json required by the API
    /// TODO:
    ///     implement
    /// </summary>
    class ItemShipments
    {

    }

    /// <summary>
    /// mimics the billingVariables section in the json required by the API
    /// TODO:
    ///     implement
    /// </summary>
    class BillingVariables
    {

    }
}

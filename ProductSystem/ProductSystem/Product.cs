using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    namespace ProductSystem
{
    class Product
    {
        int orderId;
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        int itemNo;
        public int ItemNo
        {
            get { return itemNo; }
            set { itemNo = value; }
        }

        int orderNumber;
        public int OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        string itemState;
        public string ItemState
        {
            get { return itemState; }
            set { itemState = value; }
        }



    }
}

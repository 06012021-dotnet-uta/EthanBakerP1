using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLibrary;
using RepositoryLayer;



namespace BusinessLayer
{
    public class Methods : IMethods
    {

        private readonly Project1Db _context;
        public  Methods(Project1Db context)
        {
            _context = context;
        }
        /// <summary>
        /// Add customer to database
        /// </summary>
        /// <param name="c"></param>
        public void RegisterCustomer(Customers c)
        {
            _context.Customers.Add(c);
            _context.SaveChanges();
        }

        /// <summary>
        /// Creates and saves an entry to the orders table
        /// </summary>
        /// <param name="i"></param>
        public void CreateAndSaveOrder(int i)
        {

            Orders newOrder = new Orders();
            newOrder.CustomerID = i;
            newOrder.OrderTime = DateTime.Now;
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            //for(int j = 0; j < ShoppingCart.shoppingCartProductList.Count; j++)
            //{
            //    OrderDetails newOrderDetails = new OrderDetails();
            //    newOrderDetails.Order.OrderID = newOrder.OrderID;
            //    newOrderDetails.Product = ShoppingCart.shoppingCartProductList[j];
            //    newOrderDetails.Location.LocationID = ShoppingCart.shoppingCartLocationList[j];
            //    _context.OrderDetails.Add(newOrderDetails);
            //    _context.SaveChanges();
            //}

        }
        /// <summary>
        /// Finds and returns the index of a product with a product id matching a user input int
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int FindProductIndex(int id)
        {
            for (int i = 0; i < ShoppingCart.shoppingCartProductList.Count; i++)
                if (ShoppingCart.shoppingCartProductList[i].ProductID.Equals(id))
                    return i;
            return -1;
        }
    }
}

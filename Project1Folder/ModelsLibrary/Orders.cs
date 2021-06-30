using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class Orders
    {
		[Key]
		[Display(Name = "Order Id#")]
		public int OrderID { get; set; }

		//public Customers Customer{ get; set; }
		public int CustomerID { get; set; }

		[Display(Name = "Time placed")]
		public DateTime OrderTime{ get; set; }
	}
}

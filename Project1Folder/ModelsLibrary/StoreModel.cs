using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class StoreModel
    {
		public int LocationID { get; set; }

		public int ProductID { get; set; }

		[Display(Name = "Product Name")]
		public string ProductName { get; set; }

		[Display(Name = "Price")]
		public decimal ProductPrice { get; set; }

		[Display(Name = "Description")]
		public string ProductDescription { get; set; }

		[Display(Name = "Quantity Avalible")]
		public int InventoryAmount { get; set; }
	}
}

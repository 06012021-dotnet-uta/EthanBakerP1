using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelsLibrary
{
    public class Customers
	{
		[Key]
		public int CustomerID { get; set; }

		[Required]
		[MaxLength(20)]
		[Display(Name = "First Name")]
		public string CustomerFirstName{ get; set; }

		[Required]
		[MaxLength(20)]
		[Display(Name = "Last Name")]
		public string CustomerLastName { get; set; }

	}
}

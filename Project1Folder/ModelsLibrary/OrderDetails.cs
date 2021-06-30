﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
	public class OrderDetails
	{
		[Key]
		public int DetailsID { get; set; }

		public Orders Order { get; set; }

		public Locations Location { get; set; }

		public Products Product { get; set; }
	}

}
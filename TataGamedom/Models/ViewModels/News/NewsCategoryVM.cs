﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TataGamedom.Models.ViewModels.News
{
	public class NewsCategoryVM
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }
	}
}
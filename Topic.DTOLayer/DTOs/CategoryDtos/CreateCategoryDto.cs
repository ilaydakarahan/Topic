﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic.DTOLayer.DTOs.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public bool Status { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
	}
}

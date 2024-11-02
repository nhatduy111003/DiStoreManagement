﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}

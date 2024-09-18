using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace back.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; } = 0;
        public string InternalReferance { get; set; }
        public int ShellId { get; set; }
        public string InventoryStatus { get; set; }
        public int Rating { get; set; }
        public long CreateAt { get; set; }
        public long UpdateAt { get; set; }
    }
}
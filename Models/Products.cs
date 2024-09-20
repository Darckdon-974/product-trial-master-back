
using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Price { get; set; }
        public int Quantity { get; set; } = 0;
        public string InternalReferance { get; set; }
        public int ShellId { get; set; }
        public string InventoryStatus { get; set; }
        public int Rating { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}
using System.ComponentModel.DataAnnotations;

namespace OleevAppK310.Models
{
    public class SaleProduct
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Header { get; set; } = null!;
        public string SubHeader { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? Discount { get; set; }
        [MaxLength(500)]
        public string? PhotoUrl { get; set; }
    }
}
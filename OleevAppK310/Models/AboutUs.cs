using System.ComponentModel.DataAnnotations;

namespace OleevAppK310.Models
{
    public class AboutUs
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Header { get; set; } = null!;
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? PhotoUrl { get; set; }
    }
}

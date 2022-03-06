using System.ComponentModel.DataAnnotations;

namespace OleevAppK310.Models
{
    public class ReservCategory
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }
}

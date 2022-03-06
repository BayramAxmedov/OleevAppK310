using System.ComponentModel.DataAnnotations;

namespace OleevAppK310.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string FullName { get; set; } = null!;
        [MaxLength(200)]
        public string EmailAdress { get; set; } = null!;
        public string WorkArea { get; set; } = null!;
        [MaxLength(600)]
        public string? PhotoUrl { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace OleevAppK310.Models
{
    public class Reserv
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string FullName { get; set; } = null!;
        [MaxLength(200)]
        public string EmailAdress { get; set; } = null!;
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = null!;
        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public int? ReservCategoryId { get; set; }
        public virtual ReservCategory ReservCategory { get; set; }
        public DateTime ReservDate { get; set; }
        [MaxLength(300)]
        public string Message { get; set; }


    }
}
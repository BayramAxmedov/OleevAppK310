using System.ComponentModel.DataAnnotations;

namespace OleevAppK310.Models
{
    public class Service
    {
        public int id { get; set; }
        [MaxLength(600)]
        public string icon { get; set; } 
        [MaxLength(200)]
        public string Header { get; set; } 
        [MaxLength(800)]
        public string Description { get; set; }
        [MaxLength(800)]
        public string PhotoUrl { get; set; } 

        public static implicit operator Service(string v)
        {
            throw new NotImplementedException();
        }
    }
}

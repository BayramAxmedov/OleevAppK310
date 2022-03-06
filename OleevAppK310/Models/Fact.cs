using System.ComponentModel.DataAnnotations;

namespace OleevAppK310.Models
{
    public class Fact
    {
        public int Id { get; set; }
        public string Header { get; set; } = null!;
        public int NumberCon { get; set; } 
    }
}

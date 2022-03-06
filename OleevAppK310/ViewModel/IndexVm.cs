using OleevAppK310.Models;

namespace OleevAppK310.ViewModel
{
    public class IndexVm
    {
            public Section1 Section1Info { get; set; }
        public List<Service> Services { get; set; }
        public List<Doctor>? Doctors { get; set; }
        public List<ReservCategory> ReservCategories { get; set; }
        public  AboutUs AboutUs { get; set; }   
        public SaleProduct SaleProduct { get; set; }
        public List<Fact> Facts { get; set; }




    }
}

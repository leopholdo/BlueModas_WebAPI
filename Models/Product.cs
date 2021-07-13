using System.ComponentModel.DataAnnotations;

namespace BlueModas_WebAPI.Models
{
    public class TabProduct
    {
        [Key]
        public int tprID { get; set; }
        public string tprName { get; set; }
        public double tprPrice { get; set; }
        public string tprImage { get; set; }
    }
}
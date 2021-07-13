using System.ComponentModel.DataAnnotations;

namespace BlueModas_WebAPI.Models
{
    public class TabClient
    {
        [Key]
        public int tclID { get; set; }
        public string tclName { get; set; }
        public string tclEmail { get; set; }
        public string tclPhone { get; set; }
    }
}
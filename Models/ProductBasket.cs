using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueModas_WebAPI.Models
{
    public class TabProductBasket
    {
        [Key]
        public int tpbID { get; set; }
        [ForeignKey("TabProduct")]
        public int tpbtprID { get; set; }
        [ForeignKey("TabOrder")]
        public int tpbtorID { get; set; }
        public int tpbQuantity { get; set; }
        public double tpbPriceUnity { get; set; }
        public virtual TabProduct TabProduct { get; set; }
    }
}
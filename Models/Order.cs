using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueModas_WebAPI.Models
{
    public class TabOrder
    {
        [Key]
        public int torID { get; set; }
        [ForeignKey("TabClient")]
        public int tortclID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime torDate { get; set; }
    }

    public class OrderEntity
    {
        public TabClient client { get; set; }
        public TabOrder order { get; set; }
        public List<TabProductBasket> productBasketList { get; set; }
    }

}
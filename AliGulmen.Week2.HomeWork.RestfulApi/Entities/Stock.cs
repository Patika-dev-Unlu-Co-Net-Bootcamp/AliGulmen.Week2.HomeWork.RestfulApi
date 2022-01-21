using System.ComponentModel.DataAnnotations;

namespace AliGulmen.Week2.HomeWork.RestfulApi.Entities
{
    public class Stock
    {
        [Required]
        public int productId { get; set; }

        public int readyToShip { get; set; }
        public int stockOnRack { get; set; }
    }
}

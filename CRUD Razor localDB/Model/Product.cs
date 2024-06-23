using System.ComponentModel.DataAnnotations;

namespace CRUD_Razor_localDB.Model
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Nombre del producto")]

        public string name { get; set; }
        [Display(Name = "Descriocion del producto")]
        public string description { get; set; }

        [Required]
        [Display(Name = "Precio del producto")]
        public int price { get; set; }

        [Required]
        [Display(Name = "Cantidad en Stock")]
        public int quantity { get; set; }

        [Display(Name = "Fecha de creacion del producto")]
        public DateTime creationDate { get; set; }
    }
}

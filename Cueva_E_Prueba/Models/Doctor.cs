using System.ComponentModel.DataAnnotations;

namespace Cueva_E_Prueba.Models
{
    public class Doctor
    {
        [Key]
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public int Experience { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        [Required]
        [StringLength(100)]
        public string Reason { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        public bool NeedMed { get; set; }

        public void CalcularPrecio()
        {
            TotalPrice = Reason switch
            {
                "Vacunacion" => 30,
                "Revision General" => 20,
                "Cirugia" => 100,
                _ => 0
            };
        }
    }
}

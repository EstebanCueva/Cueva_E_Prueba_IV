using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cueva_E_Prueba.Models
{
    public class PetOwner
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 120)]
        public int Age { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public bool HasMultiplePets { get; set; }

        public float Budget { get; set; }

        [Required]
        public string IdPet { get; set; }

        [ForeignKey("IdPet")]
        public Pet? Pet { get; set; }

        [Required]
        public string IdDoctor { get; set; }

        [ForeignKey("IdDoctor")]
        public Doctor? Doctor { get; set; }
    }

}

using System.ComponentModel.DataAnnotations;

namespace Cueva_E_Prueba.Models
{
    public class Pet
    {
        [Key]
        public string Id { get; set; } 

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string PetBreed { get; set; }

        [Required]
        public int Age { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public bool IsPureBreed { get; set; }

        public float Weight { get; set; }

        //public string EstebanCueva { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace First.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

    }
}
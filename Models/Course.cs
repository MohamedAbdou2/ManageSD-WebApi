using System.ComponentModel.DataAnnotations;

namespace ManageSD_WebApi.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public int Duration { get; set; }
    }
}

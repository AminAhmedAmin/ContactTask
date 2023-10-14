using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ContactTask.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        [Required]
        public string Phone { get; set; }


        [Required]
        public string Adress { get; set; }


        [Required]
        public string Notes { get; set; }


        public bool IsLocked { get; set; } = false;


        public bool IsDeleted    { get; set; } = false;









    }
}

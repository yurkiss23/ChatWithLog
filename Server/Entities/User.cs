using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities
{
    [Table("CWL_Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 75)]
        public string Name { get; set; }
        [Required,StringLength(maximumLength: 256)]
        public string Password { get; set; }
        [Required]
        public string Photo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Subscription
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; } = false;

        [Required]
        public string Amount { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

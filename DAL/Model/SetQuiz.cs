using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class SetQuiz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CreateBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool IsPublic { get; set; } = false;
        public string Type { get; set; }

        [Required, StringLength(255)]
        public string Title { get; set; }

        [Required, StringLength(255)]
        public string Description { get; set; }

        [ForeignKey("CreateBy")]
        public virtual User User { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int SetId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public long Mode { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("SetId")]
        public virtual SetQuiz SetQuiz { get; set; }

        public virtual ICollection<QuizResult> QuizResults { get; set; }
    }
}

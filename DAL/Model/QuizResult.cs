using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class QuizResult
    {
        [Key]
        public int Id { get; set; }

        public int SessionId { get; set; }
        public double Score { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public DateTime CompleteAt { get; set; }

        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }
    }
}

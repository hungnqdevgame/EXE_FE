using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Payment
    {
        [Key]
        public string Id { get; set; }

        public int UserId { get; set; }
        public int Amount { get; set; }
       
        public bool IsSuccess { get; set; }
        public DateTime CreateAt { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}

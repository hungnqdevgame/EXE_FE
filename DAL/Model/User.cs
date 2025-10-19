using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    // Kế thừa IdentityUser<int> (dùng khóa chính là int)
    public class User : IdentityUser<int>
    {
        // Không cần khai báo lại Id, Email, PasswordHash, PhoneNumber
        // vì IdentityUser<int> đã có sẵn.
        // Nếu bạn override lại sẽ gây lỗi mapping.

        public string FullName { get; set; }

        public bool? Gender { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int Role { get; set; } = -1;

        public int? SubscriptionId { get; set; }

        public string? Birthday { get; set; }

        [ForeignKey("SubscriptionId")]
        public virtual Subscription Subscription { get; set; }

        // Quan hệ
        public virtual ICollection<SetQuiz> SetQuizzes { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}

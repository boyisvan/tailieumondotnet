using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace hoangducvann_deso1.Models
{
    public class Member
    {
        [Key]
        public string MemberID { set; get; }
        [Required]
        public string UserName { set; get; }
        [Required]
        public string Password { set; get; }
        [Required]
        public string Age { set; get; }
        [Required]
        public string Email { set; get; }
        public virtual ICollection<Member> Members { get; set; }

    }

}

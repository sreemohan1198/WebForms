using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Data
{
    public class CustomerLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoginId { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public int LoginCount { get; set; }
        public String CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public String LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

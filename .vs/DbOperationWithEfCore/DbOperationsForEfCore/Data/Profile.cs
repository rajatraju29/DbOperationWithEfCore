using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbOperationsForEfCore.Data
{
    public class Profile
    {
        [Key, ForeignKey("User")]
        public int ProfileId { get; set; } // Will match with User.Id
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        // Navigation property to User
        public virtual User User { get; set; }
    }
    public class ProfileDto
    {
       // public string Action { get; set; } // 'create', 'read', 'update', 'delete'
        public string username { get; set; } // 'create', 'read', 'update', 'delete'

        public int ProfileId { get; set; }
        public string Name { get; set; }
       // public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }

}

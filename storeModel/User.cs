using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace storeModel
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Passwordhash { get; set; } = string.Empty;
    }
}

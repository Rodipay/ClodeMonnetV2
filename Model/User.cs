using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClodeMonnetV2.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}

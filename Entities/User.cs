using System.ComponentModel.DataAnnotations;
using study_together_api.Utilities;

namespace study_together_api.Entities
{
    public class User {

        public int Id { get; init; }

        [MaxLength(64)]
        public required string FirstName { get; set; } = string.Empty;

        [MaxLength(64)]
        public required string LastName { get; set; } = string.Empty;

        public string FullName
        {
            get
            {
                return StringUtils.ConcatWhitespace(" ", [FirstName, LastName]);
            }
        }

        [MaxLength(512)]
        public string Email { get; set; } = string.Empty;

        public virtual ICollection<Post>? Posts { get; }
    }
}
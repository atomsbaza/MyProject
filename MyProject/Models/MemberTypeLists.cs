using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class MemberTypeLists
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Member Type Name")]
        [Required]
        public string MemberTypeName { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        public bool Active { get; set; }
        [DisplayName("Costs")]
        [Required]
        public int MemberTypeCosts { get; set; }

    }
}

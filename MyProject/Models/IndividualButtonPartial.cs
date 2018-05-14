using System;
using System.Text;

namespace MyProject.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        public int? MemberTypeId { get; set; }
        public string CustomerId { get; set; }

        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");
                if (MemberTypeId != 0 && MemberTypeId != null)
                {
                    param.Append(String.Format("{0}", MemberTypeId));
                }

                if (!string.IsNullOrEmpty(CustomerId))
                {
                    param.Append(String.Format("{0}", CustomerId));
                }

                return param.ToString().Substring(0, param.Length);
            } 
        }
    }
}

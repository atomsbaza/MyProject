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
        public int? MemberId { get; set; }
        public int? CardId { get; set; }
        public int? Seriverid { get; set; }

        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder(@"/");
                if (MemberTypeId != 0 && MemberTypeId != null)
                {
                    param.Append(String.Format("{0}", MemberTypeId));
                }

                return param.ToString().Substring(0, param.Length);
            } 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gigsy2.Core.Entities.Common
{
    public class ContactInfo
    {
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
    
        public List<AdditionalContactDetail> AdditionalContactDetails { get; set; } = new();
    }

    public class AdditionalContactDetail
    {
    public string Type { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public bool IsPrimary { get; set; }
    }
}

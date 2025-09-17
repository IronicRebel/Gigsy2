using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Gigsy2.Core.Entities.Host
{
    public class HostProfile
    {

        [Key]
        public Guid hId { get; set; }

        public Guid gupLUId { get; set; } // Lookup GUID to link with Gigsy2User


    }
}

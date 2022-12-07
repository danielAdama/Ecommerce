using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data.Entities
{
    public class EcommerceUser : IdentityUser<long>
    {
#nullable disable
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long RoleId { get; set; }
        public DateTimeOffset TimeCreated { get; set; }
        public DateTimeOffset TimeUpdated { get; set; }
    }

    public class ApplicationRole : IdentityRole<long> { }

    public class AccessLevel : BaseEntity
    {
#nullable disable
        public long CustomersId { get; set; }
        public string Name { get; set; }
    }

    public class AccessLevelPrivilege : BaseEntity
    {
#nullable disable
        public long AccessLevelId { get; set; }
        public int ModuleId { get; set; }
        public int FeatureId { get; set; }
        public bool CanCreate { get; set; }
        public bool CanRetrieve { get; set; }
        public bool CanUpdate { get; set; }
        public bool CanDelete { get; set; }
    }

}

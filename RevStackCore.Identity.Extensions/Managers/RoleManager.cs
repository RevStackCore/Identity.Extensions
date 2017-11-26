using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace RevStackCore.Identity.Extensions
{
    public class IdentityRoleManager<TRole,TKey> : RoleManager<TRole> where TRole : class, IIdentityRole<TKey>
    {
        public IdentityRoleManager(IIdentityRoleStore<TRole, TKey> store, IEnumerable<IRoleValidator<TRole>> roleValidators, ILookupNormalizer normalizer, 
                                   IdentityErrorDescriber errorDescriber,ILogger<RoleManager<TRole>> logger) 
            : base(store,roleValidators,normalizer,errorDescriber,logger) { }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace RevStackCore.Identity.Extensions
{
    
    public class IdentityUserManager<TUser, TKey> : UserManager<TUser> where TUser : class, IIdentityUser<TKey>
    {
		public IdentityUserManager(IIdentityUserStore<TUser, TKey> store, IOptions<IdentityOptions> optionsAccessor,
		IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators,
		IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer keyNormalizer,IdentityErrorDescriber errors, IServiceProvider serviceProvider,
                                   ILogger<UserManager<TUser>> logger)
        : base(
            store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors,
            serviceProvider, logger){}
    }



}

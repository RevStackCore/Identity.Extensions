using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RevStackCore.Pattern;

namespace RevStackCore.Identity.Extensions
{
    public static class Extensions
    {
        public static IdentityBuilder AddIdentityStores<TKey,TUser,TUserLogin,TUserClaim,TUserRole,TUserToken,TRole,
        TUserRepository,TUserLoginRepository,TUserClaimRepository,TUserRoleRepository,TUserTokenRepository,TRoleRepository>(this IdentityBuilder builder) 
            where TUser: class, IIdentityUser<TKey>
            where TUserLogin: class, IIdentityUserLogin<TKey> , new()
            where TUserClaim : class, IIdentityUserClaim<TKey>, new()
            where TUserRole : class, IIdentityUserRole<TKey> , new()
		    where TUserToken : class, IIdentityUserToken<TKey>, new()
            where TRole : class, IIdentityRole<TKey>
            where TUserRepository : class, IRepository<TUser, TKey>
            where TUserLoginRepository : class, IRepository<TUserLogin, TKey>
            where TUserClaimRepository : class, IRepository<TUserClaim, TKey>
            where TUserRoleRepository : class, IRepository<TUserRole, TKey>
            where TUserTokenRepository : class, IRepository<TUserToken, TKey>
            where TRoleRepository : class, IRepository<TRole, TKey> 
           

		{
            IServiceCollection services = builder.Services;

            services.AddTransient<IIdentityUser<TKey>, TUser>();
            services.AddTransient<IIdentityUserLogin<TKey>, TUserLogin>();
            services.AddTransient<IIdentityUserClaim<TKey>, TUserClaim>();
            services.AddTransient<IIdentityUserRole<TKey>, TUserRole>();
			services.AddTransient<IIdentityUserToken<TKey>, TUserToken>();
            services.AddTransient<IIdentityRole<TKey>, TRole>();
           

            services.AddTransient<IRepository<TUser,TKey>, TUserRepository>();
            services.AddTransient<IRepository<TUserLogin, TKey>, TUserLoginRepository>();
            services.AddTransient<IRepository<TUserClaim, TKey>, TUserClaimRepository>();
            services.AddTransient<IRepository<TUserRole, TKey>, TUserRoleRepository>();
            services.AddTransient<IRepository<TUserToken, TKey>, TUserTokenRepository>();
            services.AddTransient<IRepository<TRole, TKey>, TRoleRepository>();

            services.AddTransient<IIdentityUserStore<TUser,TKey>, IdentityUserStore<TUser,TUserLogin,TUserClaim,TUserRole,TRole,TKey,TUserToken>>();
            services.AddTransient<IIdentityRoleStore<TRole, TKey>, IdentityRoleStore<TRole, TKey>>();


			return builder;
		}
    }
}

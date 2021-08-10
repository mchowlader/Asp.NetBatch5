using Autofac;
using SocialMedia.Account.Contexts;
using SocialMedia.Account.Repositories;
using SocialMedia.Account.Services;
using SocialMedia.Account.UnitOfWorks;
using System;

namespace SocialMedia.Account
{
    public class AccountModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;
        public AccountModule(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<AccountDbContext>().As<IAccountDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<AccountUnitOfWork>().As<IAccountUnitOfWork>()
               .InstancePerLifetimeScope();
            builder.RegisterType<PhotoRepository>().As<IPhotoRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>()
              .InstancePerLifetimeScope();
            builder.RegisterType<PhotoService>().As<IPhotoService>()
              .InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>()
              .InstancePerLifetimeScope();
            base.Load(builder);
        }

    }
}

using Autofac;
using SocialNetwork.Account.Contexts;
using SocialNetwork.Account.Repositories;
using SocialNetwork.Account.Services;
using SocialNetwork.Account.UnitOfWorks;
using SocialNetwork.Data;
using System;

namespace SocialNetwork.Account
{
    public class AccountModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public AccountModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AccountDbContext>().AsSelf()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationAssemblyName", _migrationAssemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<AccountDbContext>().As<IAccountDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationAssemblyName", _migrationAssemblyName)
               .InstancePerLifetimeScope();

            builder.RegisterType<MemberService>().As<IMemberService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<PhotoService>().As<IPhotoService>()
              .InstancePerLifetimeScope();
            builder.RegisterType<AccountUnitOfWork>().As<IAccountUnitOfWork>()
                .InstancePerLifetimeScope();
            builder.RegisterType<MemberRepository>().As<IMemberRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<PhotoRepository>().As<IPhotoRepository>()
               .InstancePerLifetimeScope();


            base.Load(builder); 
        }

    }
}

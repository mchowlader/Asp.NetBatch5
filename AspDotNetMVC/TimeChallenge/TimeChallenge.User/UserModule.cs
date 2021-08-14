using Autofac;
using System;
using TimeChallenge.User.Contexts;
using TimeChallenge.User.Repositories;
using TimeChallenge.User.Services;
using TimeChallenge.User.UnitOfWorks;

namespace TimeChallenge.User
{
    public class UserModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;

        public UserModule(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<UserDbContext>().As<IUserDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
               .InstancePerLifetimeScope();


            builder.RegisterType<UserService>().As<IUserService>()
               .InstancePerLifetimeScope();
            builder.RegisterType<UserUnitOfWork>().As<IUserUnitOfWork>()
               .InstancePerLifetimeScope(); 
            builder.RegisterType<UserRepository>().As<IUserRepository>()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}

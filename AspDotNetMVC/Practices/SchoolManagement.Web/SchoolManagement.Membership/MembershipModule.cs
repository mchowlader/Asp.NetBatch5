using Autofac;
using SchoolManagement.Membership.Contexts;
using System;

namespace SchoolManagement.Membership
{
    public class MembershipModule : Module
    {

        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;
        public MembershipModule(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
               .InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
               .InstancePerLifetimeScope();

            

            base.Load(builder);
        }
    }
}

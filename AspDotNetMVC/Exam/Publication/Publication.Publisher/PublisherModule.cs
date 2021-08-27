using Autofac;
using Publication.Publisher.Contexts;
using Publication.Publisher.Repositories;
using Publication.Publisher.Services;
using Publication.Publisher.UnitOfWorks;
using System;

namespace Publication.Publisher
{
    public class PublisherModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationsAssemblyName;
        public PublisherModule(string connectionString, string migrationsAssemblyName)
        {
            _connectionString = connectionString;
            _migrationsAssemblyName = migrationsAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PublisherDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<PublisherDbContext>().As<IPublisherDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationsAssemblyName", _migrationsAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<PublisherUnitOfWork>().As<IPublisherUnitOfWork>()
               .InstancePerLifetimeScope();
            
            builder.RegisterType<BookService>().As<IBookService>()
               .InstancePerLifetimeScope(); 
            builder.RegisterType<AuthorService>().As<IAuthorService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>()
               .InstancePerLifetimeScope(); 
            builder.RegisterType<BookRepository>().As<IBookRepository>()
               .InstancePerLifetimeScope();


            base.Load(builder);
        }

    }
}

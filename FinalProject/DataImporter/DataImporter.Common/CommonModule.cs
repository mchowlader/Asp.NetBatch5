using Autofac;
using DataImporter.Common.Utilities;

namespace DataImporter.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>()
                .InstancePerLifetimeScope();
            builder.RegisterType<EmailService>().As<IEmailService>()
               //.WithParameter(string host, int port, string username,
               //string password, bool useSSl, string from)
               .WithParameter("host", "smtp.gmail.com")
               .WithParameter("port", "465")
               .WithParameter("username", "spyshadaw@gmail.com")
               .WithParameter("password", "@SpyShadaw222@")
               .WithParameter("useSSl", true)
               .WithParameter("from", "spyshadaw@gmail.com");

            base.Load(builder);
        }
    }
}

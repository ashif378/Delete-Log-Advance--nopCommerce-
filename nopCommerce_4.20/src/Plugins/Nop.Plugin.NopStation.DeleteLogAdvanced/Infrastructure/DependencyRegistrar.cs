using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Factories;
using Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Area.Admin.Services;

namespace Nop.Plugin.Widgets.Intelisale.DeleteLogByDate.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<DeleteLogByDateService>().As<IDeleteLogByDateService>().InstancePerLifetimeScope();
            builder.RegisterType<DeleteLogByDateModelFactory>().As<IDeleteLogByDateModelFactory>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 10;
    }
}
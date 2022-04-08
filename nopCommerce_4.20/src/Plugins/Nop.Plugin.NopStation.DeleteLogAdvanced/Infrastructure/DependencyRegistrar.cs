using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Factories;
using Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Area.Admin.Services;

namespace Nop.Plugin.Widgets.NopStation.DeleteLogAdvanced.Infrastructure
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
            builder.RegisterType<DeleteLogAdvancedService>().As<IDeleteLogAdvancedService>().InstancePerLifetimeScope();
            builder.RegisterType<DeleteLogAdvancedModelFactory>().As<IDeleteLogAdvancedModelFactory>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order => 10;
    }
}
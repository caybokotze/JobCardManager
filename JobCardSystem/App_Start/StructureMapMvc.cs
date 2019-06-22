
using JobCardSystem.DependencyResolution;
using JobCardSystem;
using WebActivatorEx;
using System.Web.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using StructureMap;

[assembly: System.Web.PreApplicationStartMethod(typeof(StructureMapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructureMapMvc), "End")]

namespace JobCardSystem
{
    public static class StructureMapMvc
    {
        #region Public Properties

        public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

        #endregion

        #region Public Methods and Operators

        public static void End()
        {
            StructureMapDependencyScope.Dispose();
        }

        public static void Start()
        {
            IContainer container = IoC.Initialize();
            StructureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(StructureMapDependencyScope);
            DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
        }

        #endregion
    }
}
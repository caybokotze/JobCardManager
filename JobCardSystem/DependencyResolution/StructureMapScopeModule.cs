using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Web.Pipeline;

namespace JobCardSystem.DependencyResolution
{
    public class StructureMapScopeModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (sender, e) => StructureMapMvc.StructureMapDependencyScope.CreateNestedContainer();
            context.EndRequest += (sender, e) => {
                HttpContextLifecycle.DisposeAndClearAll();
                StructureMapMvc.StructureMapDependencyScope.DisposeNestedContainer();
            };
        }

        public void Dispose()
        {
        }
    }
}
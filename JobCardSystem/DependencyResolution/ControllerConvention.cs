using System;

using StructureMap.Graph.Scanning;

using System.Web.Mvc;

using StructureMap.Graph;
using StructureMap.Pipeline;
using StructureMap.TypeRules;

namespace JobCardSystem.DependencyResolution
{
    public class ControllerConvention : IRegistrationConvention
    {
        #region Public Methods and Operators.
        public void Process(Type type, StructureMap.Registry registry)
        {
            if (type.CanBeCastTo<Controller>() && !type.IsAbstract)
            {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }

        #endregion

        public void ScanTypes(TypeSet types, StructureMap.Registry registry)
        {

        }
    }
}
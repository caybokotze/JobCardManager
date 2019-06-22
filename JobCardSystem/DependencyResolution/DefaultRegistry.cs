
using StructureMap;

namespace JobCardSystem.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });
            //For<IExample>().Use<Example>();
        }

        #endregion
    }
}
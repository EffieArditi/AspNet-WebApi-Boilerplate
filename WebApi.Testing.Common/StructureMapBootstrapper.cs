using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using WebApi.Repository;

namespace WebApi.Testing.Common
{
    public class StructureMapBootstrapper : IBootstrapper
    {
        private static bool _hasStarted;

        public virtual void BootstrapStructureMap()
        {
            string connString = ConfigurationHelper.GetCurrentEnvDbConnString();
            ObjectFactory.Initialize(cfg =>
            {
                cfg.AddRegistry(new RepositoryIoCRegistry(connString));
               // cfg.AddRegistry(new ManagersRegistry(clickatellServiceUsername, clickatellPassword, clickatellApiId, clickatellSender, pushoverApplicationToken, mixPanelApplicationToken, currentEnvHachikoMessageLink));
            });

            _hasStarted = true;
        }

        public static void Restart()
        {
            if (_hasStarted)
            {
                ObjectFactory.ResetDefaults();
            }
            else
            {
                Bootstrap();
                _hasStarted = true;
            }
        }

        public static void Bootstrap()
        {
            new StructureMapBootstrapper().BootstrapStructureMap();
        }
    }
}

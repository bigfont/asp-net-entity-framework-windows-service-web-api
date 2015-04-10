using System;
using System.Collections;
using System.Configuration.Install;
using System.ServiceProcess;
using System.ComponentModel;

namespace MyWindowsService
{
    [RunInstaller(true)]
    public class Installer : System.Configuration.Install.Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        public Installer()
        {
            // Instantiate installers for process and services.
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            // The services run under the system account.
            processInstaller.Account = ServiceAccount.LocalSystem;

            // The services are started automatically.
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            // ServiceName must equal those on ServiceBase derived classes.
            serviceInstaller.ServiceName = "MyService";

            // Add installers to collection. Order is not important.
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }
    }
}

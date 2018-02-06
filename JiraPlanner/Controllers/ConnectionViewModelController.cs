using System.Runtime.InteropServices;
using System.Security;
using System.Threading.Tasks;
using ReactiveUI;
using TheBoyKnowsClass.JiraPlanner.ViewModels;

namespace TheBoyKnowsClass.JiraPlanner.Controllers
{
    public static class ConnectionViewModelController
    {
        public static void Initialize(ConnectionViewModel connectionViewModel)
        {
            var canConnect = connectionViewModel.WhenAny(vm => vm.LoginEmailAddress, vm => vm.LoginPassword, (e, p) => !(string.IsNullOrEmpty(e.Value) || p != null));
            connectionViewModel.ConnectCommand = ReactiveCommand.Create(async () => await ConnectToJira(connectionViewModel), canConnect);
        }

        private static async Task ConnectToJira(ConnectionViewModel connectionViewModel)
        {
            connectionViewModel.IsConnected = false;
            connectionViewModel.IsConnecting = true;
            connectionViewModel.IsProjectSelected = false;

            connectionViewModel.Projects.Clear();

            Jira.SDK.Jira jira = new Jira.SDK.Jira();
            await Task.Run(() =>
                {
                    jira.Connect(connectionViewModel.Url, connectionViewModel.LoginEmailAddress, GetInsecureString(connectionViewModel.LoginPassword));
                    connectionViewModel.Projects.AddRange(jira.GetProjects());
                });

            connectionViewModel.IsConnected = true;
            connectionViewModel.IsConnecting = false;
        }

        private static string GetInsecureString(SecureString secureString)
        {
            try
            {
                return Marshal.PtrToStringBSTR(Marshal.SecureStringToBSTR(secureString));
            }
            catch
            {
                return null;
            }
        }
    }
}
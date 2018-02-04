using System;
using System.Linq;
using ReactiveUI;
using TheBoyKnowsClass.JiraPlanner.ViewModels;

namespace TheBoyKnowsClass.JiraPlanner.Controllers
{
    public static class MainViewModelController
    {
        public static void Initialize(MainViewModel mainViewModel)
        {
            mainViewModel.Email = Properties.Settings.Default.Email;
            mainViewModel.Password = Properties.Settings.Default.Password;

            mainViewModel.WhenAnyValue(vm => vm.Email).Subscribe(change =>
            {
                Properties.Settings.Default.Email = change;
            });

            mainViewModel.WhenAnyValue(vm => vm.Password).Subscribe(change =>
            {

                Properties.Settings.Default.Password = change;
            });

            mainViewModel.WhenAnyValue(vm => vm.SelectedProject).Subscribe(observer =>
            {
                if (observer == null)
                {
                    mainViewModel.IsProjectSelected = false;
                    return;
                }

                mainViewModel.IsProjectSelected = true;

                Properties.Settings.Default.Project = observer.Name;
                Properties.Settings.Default.Save();
                mainViewModel.ProjectVersions.Clear();

                if (observer.ProjectVersions.Any())
                {
                    mainViewModel.ProjectVersions.AddRange(observer.ProjectVersions);
                }

                mainViewModel.SelectedProjectVersion = mainViewModel.ProjectVersions.FirstOrDefault(p => p.Name == Properties.Settings.Default.Version);

            });

            mainViewModel.WhenAnyValue(vm => vm.SelectedProjectVersion).Subscribe(observer =>
            {
                if (observer == null)
                {
                    mainViewModel.IsProjectVersionSelected = false;
                    return;
                }

                Properties.Settings.Default.Version = observer.Name;
                Properties.Settings.Default.Save();
                mainViewModel.IsProjectVersionSelected = true;

            });

            var canConnect = mainViewModel.WhenAny(vm => vm.Email, vm => vm.Password, (e, p) => !(string.IsNullOrEmpty(e.Value) || string.IsNullOrEmpty(p.Value)));

            mainViewModel.ConnectCommand = ReactiveCommand.Create(() => ConnectToJira(mainViewModel), canConnect);
        }

        private static void ConnectToJira(MainViewModel mainViewModel)
        {
            Properties.Settings.Default.Save();
            mainViewModel.IsConnected = false;
            mainViewModel.IsConnecting = true;
            mainViewModel.IsProjectSelected = false;
            mainViewModel.IsProjectVersionSelected = false;
            Jira.SDK.Jira jira = new Jira.SDK.Jira();
            jira.Connect(Properties.Settings.Default.Url, Properties.Settings.Default.Email, Properties.Settings.Default.Password);


            mainViewModel.Projects.Clear();
            mainViewModel.Projects.AddRange(jira.GetProjects());

            mainViewModel.SelectedProject = mainViewModel.Projects.FirstOrDefault(p => p.Name == Properties.Settings.Default.Project);

            mainViewModel.IsConnected = true;
            mainViewModel.IsConnecting = false;
        }
    }
}
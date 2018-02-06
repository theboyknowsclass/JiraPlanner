using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using ReactiveUI;
using TheBoyKnowsClass.JiraPlanner.ViewModels;

namespace TheBoyKnowsClass.JiraPlanner.Controllers
{
    public static class MainViewModelController
    {
        public static void Initialize(MainViewModel mainViewModel)
        {
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
        }
    }
}
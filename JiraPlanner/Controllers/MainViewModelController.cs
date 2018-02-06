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
            mainViewModel.WhenAnyValue(vm => vm.SelectedProject).Subscribe(observer =>
            {
                if (observer == null)
                {
                    mainViewModel.IsProjectSelected = false;
                    return;
                }

                mainViewModel.IsProjectSelected = true;

                mainViewModel.ProjectVersions.Clear();

                if (observer.ProjectVersions.Any())
                {
                    mainViewModel.ProjectVersions.AddRange(observer.ProjectVersions);
                }
            });

            mainViewModel.WhenAnyValue(vm => vm.SelectedProjectVersion).Subscribe(observer =>
            {
                if (observer == null)
                {
                    mainViewModel.IsProjectVersionSelected = false;
                    return;
                }

                mainViewModel.IsProjectVersionSelected = true;

            });
        }
    }
}
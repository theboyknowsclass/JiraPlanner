using System.Security;
using Jira.SDK.Domain;
using ReactiveUI;
using TheBoyKnowsClass.JiraPlanner.Controllers;

namespace TheBoyKnowsClass.JiraPlanner.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private ProjectVersion _selectedProjectVersion;
        private bool _isProjectVersionSelected;

        public MainViewModel()
        {
            MainViewModelController.Initialize(this);
        }

        public ConnectionsViewModel Connections = new ConnectionsViewModel();

        public ReactiveList<ProjectVersion> ProjectVersions { get; } = new ReactiveList<ProjectVersion>();

        public ProjectVersion SelectedProjectVersion
        {
            get => _selectedProjectVersion;
            set => this.RaiseAndSetIfChanged(ref _selectedProjectVersion, value);
        }

        public bool IsProjectVersionSelected
        {
            get => _isProjectVersionSelected;
            set => this.RaiseAndSetIfChanged(ref _isProjectVersionSelected, value);
        }
    }
}
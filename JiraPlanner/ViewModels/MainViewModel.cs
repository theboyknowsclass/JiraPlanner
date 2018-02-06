using System.Security;
using System.Xml.Serialization;
using Jira.SDK.Domain;
using ReactiveUI;
using TheBoyKnowsClass.JiraPlanner.Controllers;

namespace TheBoyKnowsClass.JiraPlanner.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private ProjectVersion _selectedProjectVersion;
        private bool _isProjectVersionSelected;
        private Project _selectedProject;
        private bool _isProjectSelected;


        public MainViewModel()
        {
            MainViewModelController.Initialize(this);
        }

        public ConnectionsViewModel Connections = new ConnectionsViewModel();

        public ConnectionViewModel SelectedConnection { get; set; }

        public Project SelectedProject
        {
            get => _selectedProject;
            set => this.RaiseAndSetIfChanged(ref _selectedProject, value);
        }

        public bool IsProjectSelected
        {
            get => _isProjectSelected;
            set => this.RaiseAndSetIfChanged(ref _isProjectSelected, value);
        }


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
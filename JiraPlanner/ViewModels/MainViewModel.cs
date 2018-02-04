using Jira.SDK.Domain;
using ReactiveUI;
using TheBoyKnowsClass.JiraPlanner.Controllers;

namespace TheBoyKnowsClass.JiraPlanner.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private string _email;
        private string _password;
        private Project _selectedProject;
        private ProjectVersion _selectedProjectVersion;
        private bool _isconnecting;
        private bool _isconnected;
        private bool _isProjectVersionSelected;
        private bool _isProjectSelected;

        public MainViewModel()
        {
            MainViewModelController.Initialize(this);
        }

        public string Email
        {
            get => _email;
            set => this.RaiseAndSetIfChanged(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public ReactiveCommand ConnectCommand { get; set; }

        public ReactiveList<Project> Projects { get; } = new ReactiveList<Project>();

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

        public bool IsConnecting
        {
            get => _isconnecting;
            set => this.RaiseAndSetIfChanged(ref _isconnecting, value);
        }

        public bool IsConnected
        {
            get => _isconnected;
            set => this.RaiseAndSetIfChanged(ref _isconnected, value);
        }
    }
}
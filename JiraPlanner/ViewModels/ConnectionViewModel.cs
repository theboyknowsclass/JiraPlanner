using System.Configuration;
using System.Security;
using System.Xml.Serialization;
using Jira.SDK.Domain;
using ReactiveUI;
using TheBoyKnowsClass.JiraPlanner.Controllers;

namespace TheBoyKnowsClass.JiraPlanner.ViewModels
{
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class ConnectionViewModel : ReactiveObject
    {
        private string _connectionName;
        private string _url;
        private string _loginEmailAddress;
        private SecureString _loginPassword;
        private string _project;
        private bool _saveLoginPassword;
        private bool _connectByDefault;
        private Project _selectedProject;
        private bool _isProjectSelected;
        private bool _isconnecting;
        private bool _isconnected;

        public ConnectionViewModel()
        {
            ConnectionViewModelController.Initialize(this);
        }

        public string ConnectionName
        {
            get => _connectionName;
            set => this.RaiseAndSetIfChanged(ref _connectionName, value);
        }

        public string Url
        {
            get => _url;
            set => this.RaiseAndSetIfChanged(ref _url, value);
        }

        public string LoginEmailAddress
        {
            get => _loginEmailAddress;
            set => this.RaiseAndSetIfChanged(ref _loginEmailAddress, value);
        }

        [XmlIgnore]
        public SecureString LoginPassword
        {
            get => _loginPassword;
            set => this.RaiseAndSetIfChanged(ref _loginPassword, value);
        }

        [XmlIgnore]
        public bool SaveLoginPassword
        {
            get => _saveLoginPassword;
            set => this.RaiseAndSetIfChanged(ref _saveLoginPassword, value);
        }

        public bool ConnectByDefault
        {
            get => _connectByDefault;
            set => this.RaiseAndSetIfChanged(ref _connectByDefault, value);
        }

        [XmlIgnore]
        public ReactiveCommand ConnectCommand { get; set; }

        [XmlIgnore]
        public ReactiveList<Project> Projects { get; } = new ReactiveList<Project>();

        [XmlIgnore]
        public Project SelectedProject
        {
            get => _selectedProject;
            set => this.RaiseAndSetIfChanged(ref _selectedProject, value);
        }

        [XmlIgnore]
        public bool IsProjectSelected
        {
            get => _isProjectSelected;
            set => this.RaiseAndSetIfChanged(ref _isProjectSelected, value);
        }

        public string Project
        {
            get => _project;
            set => this.RaiseAndSetIfChanged(ref _project, value);
        }

        [XmlIgnore]
        public bool IsConnecting
        {
            get => _isconnecting;
            set => this.RaiseAndSetIfChanged(ref _isconnecting, value);
        }

        [XmlIgnore]
        public bool IsConnected
        {
            get => _isconnected;
            set => this.RaiseAndSetIfChanged(ref _isconnected, value);
        }
    }
}
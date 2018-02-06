using System.Configuration;
using ReactiveUI;

namespace TheBoyKnowsClass.JiraPlanner.ViewModels
{
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class ConnectionsViewModel
    {
        public ReactiveList<ConnectionViewModel> Items = new ReactiveList<ConnectionViewModel>();
    }
}
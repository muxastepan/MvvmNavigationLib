using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MvvmNavigationLib.Stores.Messages
{
    public class ViewModelChangedMessage : ValueChangedMessage<ObservableObject>
    {
        public ViewModelChangedMessage(ObservableObject value) : base(value)
        {
        }
    }
}

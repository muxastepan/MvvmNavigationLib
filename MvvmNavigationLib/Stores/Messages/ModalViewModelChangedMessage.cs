using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MvvmNavigationLib.Stores.Messages
{
    public class ModalViewModelChangedMessage : ValueChangedMessage<ObservableObject>
    {
        public ModalViewModelChangedMessage(ObservableObject value) : base(value)
        {
        }
    }
}

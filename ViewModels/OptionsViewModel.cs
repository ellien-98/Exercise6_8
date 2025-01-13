using System.Collections.ObjectModel;
using System.Net;
using System.Windows.Input;

namespace Exercise6_8_NET8.ViewModels {
    public class OptionsViewModel : BindableObject{
        public ObservableCollection<Option> MenuOptions {get; }
        public ICommand SelectMenuOption {get; }
        public ICommand CancelOrderCmd {get; }

        private bool beingPrepared; 
        public bool BeingPrepared{
            get=>beingPrepared;
            set {
                beingPrepared=value;
                OnPropertyChanged();
            }
        }

        private string msg=string.Empty;

        public string Message{
            get => msg;
            set{
                msg=value;
                OnPropertyChanged();
            }
        }

        public OptionsViewModel(){
            MenuOptions = new ObservableCollection<Option> {
                new Option("Mushroom Risotto"),
                new Option("Cheddar Potatoes"),
                new Option("Pizza")
            };

            SelectMenuOption = new Command<Option> (async(userChoice) => await StartCooking(userChoice));
            CancelOrderCmd=new Command(CancelOrder);

        }

        private async Task StartCooking (Option userChoice){
            if(BeingPrepared){
                Message = "You have already made a choice and it is being prepared";
                return;
            }
            BeingPrepared = true;
            Message = $"Excellent choice! We are preparing you {userChoice.Name}";
            await Task.Delay(5000);

            if(BeingPrepared){
                Message=$"Your {userChoice.Name} is ready, enjoy!";           
                BeingPrepared=false;
            }

        }

        private void CancelOrder(){
            if(BeingPrepared){
                BeingPrepared=false;
                Message="Your order has been cancelled successfully";
            }
        }


    }
}
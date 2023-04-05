using ArmyEditor.Logic;
using ArmyEditor.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ArmyEditor.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        ISnackLogic logic;
        public ObservableCollection<Snacks> SnacksCollection { get; set; }

        private Snacks selectedSnack;

        public Snacks SelectedSnack
        {
            get { return selectedSnack; }
            set 
            {
                SetProperty(ref selectedSnack, value);
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditCommand as RelayCommand).NotifyCanExecuteChanged();
                (RemoveCommand as RelayCommand).NotifyCanExecuteChanged();
                (BuyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand BuyCommand { get; set; }

        public int Money
        {
            get
            {
                return logic.Money;
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
            :this(IsInDesignMode ? null : Ioc.Default.GetService<ISnackLogic>())
        {

        }

        public MainWindowViewModel(ISnackLogic logic)
        {
            this.logic = logic;
            SnacksCollection = new ObservableCollection<Snacks>();

            SnacksCollection.Add(new Snacks()
            {
                Name = "Twix",
                Price = 300,
                Quantity = 20
            });
            SnacksCollection.Add(new Snacks()
            {
                Name = "Mars",
                Price = 300,
                Quantity = 16
            });
            SnacksCollection.Add(new Snacks()
            {
                Name = "Balaton szelet",
                Price = 250,
                Quantity = 4
            });
            SnacksCollection.Add(new Snacks()
            {
                Name = "KitKat",
                Price = 350,
                Quantity = 0
            });

            logic.SetupCollections(SnacksCollection);

            AddCommand = new RelayCommand(
                () => logic.AddToCart(),
                () => selectedSnack != null
                );
            RemoveCommand = new RelayCommand(
                () => logic.RemoveFromCart(selectedSnack),
                () => selectedSnack != null
                );
            EditCommand = new RelayCommand(
                () => logic.EditSnack(selectedSnack),
                () => selectedSnack != null
                );
            BuyCommand = new RelayCommand(
                () => logic.BuySnack(selectedSnack),
                () => selectedSnack != null
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "SnackInfo", (recipient, msg) =>
            {
                 OnPropertyChanged("Money");
            });
        }
    }
}

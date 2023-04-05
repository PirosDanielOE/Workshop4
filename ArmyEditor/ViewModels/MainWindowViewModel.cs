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
        public ObservableCollection<Snacks> Barrack { get; set; }
        public ObservableCollection<Snacks> Army { get; set; }

        private Snacks selectedFromBarracks;

        public Snacks SelectedFromBarracks
        {
            get { return selectedFromBarracks; }
            set 
            {
                SetProperty(ref selectedFromBarracks, value);
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditTrooperCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Snacks selectedFromArmy;

        public Snacks SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set
            { 
                SetProperty(ref selectedFromArmy, value);
                (RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddToArmyCommand { get; set; }
        public ICommand RemoveFromArmyCommand { get; set; }
        public ICommand EditTrooperCommand { get; set; }

        public int AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }

        public double AVGPower
        {
            get
            {
                return logic.AVGPower;
            }
        }

        public double AVGSpeed
        {
            get
            {
                return logic.AVGSpeed;
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
            Barrack = new ObservableCollection<Snacks>();
            Army = new ObservableCollection<Snacks>();

            Barrack.Add(new Snacks()
            {
                Type = "marine",
                Power = 8,
                Speed = 6
            });
            Barrack.Add(new Snacks()
            {
                Type = "pilot",
                Power = 7,
                Speed = 3
            });
            Barrack.Add(new Snacks()
            {
                Type = "infantry",
                Power = 6,
                Speed = 8
            });
            Barrack.Add(new Snacks()
            {
                Type = "sniper",
                Power = 3,
                Speed = 3
            });
            Barrack.Add(new Snacks()
            {
                Type = "engineer",
                Power = 5,
                Speed = 6
            });

            Army.Add(Barrack[2].GetCopy());
            Army.Add(Barrack[4].GetCopy());

            logic.SetupCollections(Barrack, Army);

            AddToArmyCommand = new RelayCommand(
                () => logic.AddToArmy(SelectedFromBarracks),
                () => SelectedFromBarracks != null
                ) ;

            RemoveFromArmyCommand = new RelayCommand(
                () => logic.RemoveFromArmy(SelectedFromArmy),
                () => SelectedFromArmy != null
                );

            EditTrooperCommand = new RelayCommand(
                () => logic.EditTrooper(SelectedFromBarracks),
                () => SelectedFromBarracks != null
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recipient, msg) =>
             {
                 OnPropertyChanged("AllCost");
                 OnPropertyChanged("AVGPower");
                 OnPropertyChanged("AVGSpeed");
             });
        }
    }
}

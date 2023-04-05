using ArmyEditor.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ArmyEditor.ViewModels
{
    public class TrooperEditorWindowViewModel
    {
        public Snacks Actual { get; set; }

        public void Setup(Snacks trooper)
        {
            this.Actual = trooper;
        }

        
        public TrooperEditorWindowViewModel()
        {
            
        }
    }
}

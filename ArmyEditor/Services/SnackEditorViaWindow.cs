using ArmyEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyEditor.Services
{
    public class SnackEditorViaWindow : ISnackEditorService
    {
        public bool Edit(Snacks snacks)
        {
            bool? b = new SnackEditorWindow(snacks).ShowDialog();
            if (b is null)
            {
                return false;
            }
            if (b is true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

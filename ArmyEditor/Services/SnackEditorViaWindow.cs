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
        public void Edit(Snacks snacks)
        {
            new SnackEditorWindow(snacks).ShowDialog();
        }
    }
}

using ArmyEditor.Models;
using ArmyEditor.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyEditor.Logic
{
    public class SnackLogic : ISnackLogic
    {
        IList<Snacks> snack;
        IMessenger messenger;
        ISnackEditorService editorService;

        public SnackLogic(IMessenger messenger, ISnackEditorService editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
            money = 5000;
        }


        public void SetupCollections(IList<Snacks> snacks)
        {
            this.snack = snacks;
        }

        public void AddToCart(Snacks snacks)
        {
            snack.Add(snacks);
            messenger.Send("Snack added", "SnackInfo");
        }

        public void RemoveFromCart(Snacks snacks)
        {
            snack.Remove(snacks);
            messenger.Send("Snack removed", "SnackInfo");
        }

        public void EditSnack(Snacks snacks)
        {
            editorService.Edit(snacks);
        }
        private int money;
        public int Money
        {
            get
            {
                return this.money;  
            }
        } 


    }
}

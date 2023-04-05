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
        IList<Snacks> cart;
        IList<Snacks> snack;
        IMessenger messenger;
        ITrooperEditorService editorService;

        public SnackLogic(IMessenger messenger, ITrooperEditorService editorService)
        {
            this.messenger = messenger;
            this.editorService = editorService;
        }


        public void SetupCollections(IList<Snacks> carts, IList<Snacks> snacks)
        {
            this.cart = carts;
            this.snack = snacks;
        }

        public void AddToCart(Snacks snacks)
        {
            snack.Add(snacks.GetCopy());
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


    }
}

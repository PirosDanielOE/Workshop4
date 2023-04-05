using ArmyEditor.Models;
using System.Collections.Generic;

namespace ArmyEditor.Logic
{
    public interface ISnackLogic
    {
        int Money { get; }
        void AddToCart();
        void EditSnack(Snacks snacks);
        void RemoveFromCart(Snacks snacks);
        void SetupCollections(IList<Snacks> snacks);
    }
}
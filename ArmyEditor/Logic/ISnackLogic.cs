﻿using ArmyEditor.Models;
using System.Collections.Generic;

namespace ArmyEditor.Logic
{
    public interface ISnackLogic
    {

        void AddToCart(Snacks snacks);
        void EditSnack(Snacks snacks);
        void RemoveFromCart(Snacks snacks);
        void SetupCollections(IList<Snacks> carts, IList<Snacks> snacks);
    }
}
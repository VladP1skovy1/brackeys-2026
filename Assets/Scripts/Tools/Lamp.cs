using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Lamp : Tool
    {
        protected override void UseToolClick()
        {
            throw new System.NotImplementedException();
        }

        public override object Read(Item item)
            => item is IUVReactive reactive ? (object)reactive.IsUVReactive : null;
    }
}

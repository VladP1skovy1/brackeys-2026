using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Scales : Tool
    {
        protected override void OnToolClick()
        {
            throw new System.NotImplementedException();
        }

        public override object Read(Item item)
            => item is IWeighable weighable ? (object)weighable.Weight : null;
    }
}

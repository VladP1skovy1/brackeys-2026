using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Ruler : Tool
    {
        protected override void UseToolClick()
        {
            throw new System.NotImplementedException();
        }

        public override object Read(Item item)
            => item is IMeasurable measurable ? (object)measurable.Dimensions : null;
    }
}

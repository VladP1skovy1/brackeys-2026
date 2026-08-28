using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Magnifier : Tool
    {
        protected override void UseToolClick()
        {
            throw new System.NotImplementedException();
        }

        public override object Read(Item item)
            => item is IInscribed inscribed ? inscribed.Text : null;
    }
}

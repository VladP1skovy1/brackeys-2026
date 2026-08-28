using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Magnet : Tool
    {
        protected override void OnToolClick()
        {
            throw new System.NotImplementedException();
        }

        public override object Read(Item item)
            => item is IMagnetic magnetic ? (object)magnetic.IsMagnetic : null;
    }
}

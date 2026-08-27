using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    [CreateAssetMenu(fileName = "Lamp", menuName = "Scriptable Objects/Tools/Lamp")]
    public class Lamp : Tool
    {
        public override object Read(Item item)
            => item is IUVReactive reactive ? (object)reactive.IsUVReactive : null;
    }
}

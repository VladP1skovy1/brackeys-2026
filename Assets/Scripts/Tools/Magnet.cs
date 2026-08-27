using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    [CreateAssetMenu(fileName = "Magnet", menuName = "Scriptable Objects/Tools/Magnet")]
    public class Magnet : Tool
    {
        public override object Read(Item item)
            => item is IMagnetic magnetic ? (object)magnetic.IsMagnetic : null;
    }
}

using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    [CreateAssetMenu(fileName = "Magnifier", menuName = "Scriptable Objects/Tools/Magnifier")]
    public class Magnifier : Tool
    {
        public override object Read(Item item)
            => item is IInscribed inscribed ? inscribed.Text : null;
    }
}

using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    [CreateAssetMenu(fileName = "Ruler", menuName = "Scriptable Objects/Tools/Ruler")]
    public class Ruler : Tool
    {
        public override object Read(Item item)
            => item is IMeasurable measurable ? (object)measurable.Dimensions : null;
    }
}

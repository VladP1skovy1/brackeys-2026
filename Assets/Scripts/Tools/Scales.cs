using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    [CreateAssetMenu(fileName = "Scales", menuName = "Scriptable Objects/Tools/Scales")]
    public class Scales : Tool
    {
        public override object Read(Item item)
            => item is IWeighable weighable ? (object)weighable.Weight : null;
    }
}

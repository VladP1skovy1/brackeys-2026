using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Jewellery", menuName = "Scriptable Objects/Jewellery")]
    public class Jewellery : Item, IMagnetic
    {
        [field: SerializeField] public bool IsMagnetic { get; private set; }
    }
}

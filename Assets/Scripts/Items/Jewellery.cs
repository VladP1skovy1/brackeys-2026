using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Jewellery", menuName = "Scriptable Objects/Jewellery")]
    public class Jewellery : Item
    {
        [field: SerializeField] public float Weight { get; private set; }
        [field: SerializeField] public bool IsMagnetic { get; private set; }
    }
}

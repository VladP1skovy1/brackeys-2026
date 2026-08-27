using AntiqueShop.Utils;
using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
    public abstract class Item : ScriptableObject
    {
        [field: SerializeField] public Sprite ItemSprite { get; private set; }
        [field: SerializeField] public float RealPrice { get; private set; }
        [field: SerializeField] public Claim CustomerClaim { get; private set; }
        [field: SerializeField] public bool IsAuthentic { get; private set; }
    }
}

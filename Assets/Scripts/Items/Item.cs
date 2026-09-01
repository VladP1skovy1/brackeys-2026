using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
    public abstract class Item : ScriptableObject, IWeighable
    {
        [field: SerializeField] public Sprite ItemSprite { get; private set; }
        [field: SerializeField] public float RealPrice { get; private set; }
        [field: SerializeField] public float Weight { get; private set; }
        [field: SerializeField] public Claim CustomerClaim { get; private set; }
        [field: SerializeField] public bool IsAuthentic { get; private set; }

        public string Type => GetType().Name;
    }
}

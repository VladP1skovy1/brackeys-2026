using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Rock", menuName = "Scriptable Objects/Rock")]
    public class Rock : Item, IWeighable, IMagnetic, IUVReactive, IMeasurable
    {
        [field: SerializeField] public float Weight { get; private set; }
        [field: SerializeField] public bool IsMagnetic { get; private set; }
        [field: SerializeField] public Vector2 Dimensions { get; private set; }
        [field: SerializeField] public bool IsUVReactive { get; private set; }
        [field: SerializeField] public Sprite UVRockSprite { get; private set; }

        Sprite IUVReactive.UVView => UVRockSprite;
    }
}

using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Statuette", menuName = "Scriptable Objects/Statuette")]
    public class Statuette : Item
    {
        [field: SerializeField] public float Weight { get; private set; }
        [field: SerializeField] public bool IsMagnetic { get; private set; }
        [field: SerializeField] public bool IsUVReactive { get; private set; }
        [field: SerializeField] public Sprite UVStatuetteSprite { get; private set; }
    }
}

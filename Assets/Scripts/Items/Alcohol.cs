using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "Alcohol", menuName = "Scriptable Objects/Alcohol")]
    public class Alcohol : Item
    {
        [field: SerializeField] public string AlcoholText { get; private set; }
    }
}



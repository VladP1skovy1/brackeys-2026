using UnityEngine;

namespace AntiqueShop.Items
{
    [System.Serializable]
    public class Claim
    {
        [field: SerializeField] public string CustomerText { get; private set; }
        [field: SerializeField] public float AskingPrice { get; private set; }
    }
}
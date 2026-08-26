using UnityEngine;

namespace AntiqueShop
{
    [System.Serializable]
    public class Claim
    {
        [field: SerializeField] public string CustomerText { get; private set; }
        [field: SerializeField] public int AskingPrice { get; private set; }
    }
}
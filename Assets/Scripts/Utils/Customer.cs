using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Utils
{
    [System.Serializable]
    public class Customer
    {
        [field: SerializeField] public Item Item {get; private set;}
        [field: SerializeField] public Sprite CustomerSprite {get; private set;}
        [field: SerializeField] public AudioClip VoiceSound { get; private set; }
    }
}

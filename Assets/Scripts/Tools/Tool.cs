using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public abstract class Tool : ScriptableObject
    {
        [field: SerializeField] public Sprite ToolSprite { get; private set; }

        public abstract object Read(Item item);
    }
}

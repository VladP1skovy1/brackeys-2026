using System;
using UnityEngine;

namespace AntiqueShop.Items
{
    [CreateAssetMenu(fileName = "CurrentItem", menuName = "Scriptable Objects/Current Item")]
    public class CurrentItem : ScriptableObject
    {
        public event Action<Item> Changed;

        public Item Value { get; private set; }

        public void Set(Item item)
        {
            Value = item;
            Changed?.Invoke(item);
        }
    }
}

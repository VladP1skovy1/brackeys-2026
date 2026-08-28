using AntiqueShop.Items;
using AntiqueShop.UI;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Lamp : Tool
    {
        [SerializeField] private ItemUI itemView;

        protected override void OnToolClick() => itemView.Toggle(Read() as Sprite);

        public override object Read()
            => CurrentItem is IUVReactive reactive && reactive.IsUVReactive ? reactive.UVView : null;
    }
}

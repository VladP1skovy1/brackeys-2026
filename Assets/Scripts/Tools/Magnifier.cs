using AntiqueShop.Items;
using AntiqueShop.UI;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Magnifier : Tool
    {
        [SerializeField] private CloseUpView closeUp;

        protected override void OnToolClick() => closeUp.Toggle(Read() as Sprite);

        public override object Read()
            => CurrentItem is IInscribed inscribed ? inscribed.CloseUp : null;
    }
}

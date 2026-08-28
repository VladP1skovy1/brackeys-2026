using AntiqueShop.Items;
using AntiqueShop.UI;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Magnifier : Tool
    {
        [SerializeField] private CloseUpView closeUp;
        [SerializeField] private ItemUI itemUI;

        protected override void OnToolClick()
        {
            if (!itemUI.IsActive) return;

            closeUp.Toggle(CurrentItem is IInscribed inscribed ? inscribed.CloseUp : null);
        }
    }
}

using AntiqueShop.Items;
using AntiqueShop.UI;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Scales : Tool
    {
        [SerializeField] private ItemUI itemView;
        [SerializeField] private ToolReadout readout;
        [SerializeField] private Transform pan;

        protected override void OnToolClick()
        {
            if (Read() is not float weight)
            {
                return;
            }

            bool onScales = itemView.TogglePosition(pan.position);
            readout.Show(onScales ? $"{weight:0.##} g" : null);
        }
    }
}

using AntiqueShop.Items;

namespace AntiqueShop.Tools
{
    public class Lamp : Tool
    {
        protected override void OnToolClick()
        {
        }

        public override object Read()
            => CurrentItem is IUVReactive reactive ? (object)reactive.IsUVReactive : null;
    }
}

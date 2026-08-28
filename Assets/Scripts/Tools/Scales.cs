using AntiqueShop.Items;

namespace AntiqueShop.Tools
{
    public class Scales : Tool
    {
        protected override void OnToolClick()
        {
        }

        public override object Read()
            => CurrentItem is IWeighable weighable ? (object)weighable.Weight : null;
    }
}

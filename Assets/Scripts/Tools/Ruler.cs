using AntiqueShop.Items;

namespace AntiqueShop.Tools
{
    public class Ruler : Tool
    {
        protected override void OnToolClick()
        {
        }

        public override object Read()
            => CurrentItem is IMeasurable measurable ? (object)measurable.Dimensions : null;
    }
}

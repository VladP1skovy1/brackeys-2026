using AntiqueShop.Items;

namespace AntiqueShop.Tools
{
    public class Magnet : Tool
    {
        protected override void OnToolClick()
        {
        }

        public override object Read()
            => CurrentItem is IMagnetic magnetic ? (object)magnetic.IsMagnetic : null;
    }
}

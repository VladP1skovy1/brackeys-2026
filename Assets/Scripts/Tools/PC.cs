using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class PC : Tool
    {
        public readonly struct Article
        {
            public string Text { get; }
            public Sprite Image { get; }

            public bool HasContent => !string.IsNullOrEmpty(Text);

            public Article(string text, Sprite image)
            {
                Text = text;
                Image = image;
            }
        }

        [SerializeField] private Sprite alcoholImage;
        [SerializeField] private Sprite rockImage;
        [SerializeField] private Sprite statuetteImage;
        [SerializeField] private Sprite documentImage;
        [SerializeField] private Sprite jewelleryImage;

        public Article CurrentArticle => CurrentItem switch
        {
            Alcohol => new Article(ItemArticles.AlcoholArticle, alcoholImage),
            Rock => new Article(ItemArticles.RockArticle, rockImage),
            Statuette => new Article(ItemArticles.StatuetteArticle, statuetteImage),
            Document => new Article(ItemArticles.DocumentArticle, documentImage),
            Jewellery => new Article(ItemArticles.JewelleryArticle, jewelleryImage),
            _ => default
        };

        protected override void OnToolClick()
        {
        }
    }
}

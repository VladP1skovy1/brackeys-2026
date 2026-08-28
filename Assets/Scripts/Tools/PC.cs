using System;
using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class PC : Tool
    {
        [Serializable]
        public class Article
        {
            [field: SerializeField] public string ItemType { get; private set; }
            [field: SerializeField, TextArea(5, 15)] public string Text { get; private set; }
        }

        [SerializeField] private Article[] articles;

        public Article[] Articles => articles;

        protected override void UseToolClick()
        {
            throw new NotImplementedException();
        }

        public override object Read(Item item)
        {
            foreach (Article article in articles)
            {
                if (article.ItemType == item.Type)
                {
                    return article.Text;
                }
            }

            return null;
        }
    }
}

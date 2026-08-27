using System;
using AntiqueShop.Items;
using UnityEngine;

namespace AntiqueShop.Tools
{
    [CreateAssetMenu(fileName = "PC", menuName = "Scriptable Objects/Tools/PC")]
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

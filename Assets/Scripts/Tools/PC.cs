using System;
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

        protected override void OnToolClick()
        {
        }
    }
}

using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Computer : Tool
    {
        [SerializeField] private GameObject computerWindow;

        protected override void OnToolClick()
        {
            computerWindow.SetActive(true);
        }
    }
}
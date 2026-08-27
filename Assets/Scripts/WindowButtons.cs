using System;
using UnityEngine;
using UnityEngine.UI;

namespace AntiqueShop
{
    public class WindowButtons : MonoBehaviour
    {
        public static event Action<bool> OnDecisionMade; 
        
        [SerializeField] private Button acceptButton;
        [SerializeField] private Button passButton;
        
        private void OnEnable()
        {
            acceptButton.onClick.AddListener(PressAccept);
            passButton.onClick.AddListener(PressPass);
        }
        
        private void OnDisable()
        {
            acceptButton.onClick.RemoveListener(PressAccept);
            passButton.onClick.RemoveListener(PressPass);
        }

        private void PressAccept()
        {
            OnDecisionMade?.Invoke(true);
        }

        private void PressPass()
        {
            OnDecisionMade?.Invoke(false);
        }
    }
}

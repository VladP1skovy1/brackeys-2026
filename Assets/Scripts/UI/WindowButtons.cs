using System;
using AntiqueShop.Core;
using UnityEngine;
using UnityEngine.UI;

namespace AntiqueShop.UI
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
            GameManager.OnButtonsStateChanged += SetInteractable;
        }
        
        private void OnDisable()
        {
            acceptButton.onClick.RemoveListener(PressAccept);
            passButton.onClick.RemoveListener(PressPass);
            GameManager.OnButtonsStateChanged -= SetInteractable;
        }
        
        private void SetInteractable(bool state)
        {
            acceptButton.interactable = state;
            passButton.interactable = state;
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

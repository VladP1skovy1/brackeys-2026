using System;
using System.Collections;
using System.Collections.Generic;
using AntiqueShop.Items;
using AntiqueShop.UI;
using TMPro;
using UnityEngine;

namespace AntiqueShop.Core
{
    public class GameManager : MonoBehaviour
    {
        [Header("Level Data")]
        [SerializeField] private float quota;
        [SerializeField] private List<Customer> customers;

        [Header("Scene References")]
        [SerializeField] private CustomerUI customerShell;
        [SerializeField] private ItemUI itemShell;
        [SerializeField] private TextMeshProUGUI balanceText;
        [SerializeField] private TextMeshProUGUI potentialProfitText;
        [SerializeField] private TextMeshProUGUI claimText; 
        [SerializeField] private float typingDelay;
        
        [Header("End Game Panels")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        
        [Header("Audio SFX")]
        [SerializeField] private AudioClip winMoneySound;
        [SerializeField] private AudioClip loseMoneySound;
        [SerializeField] private AudioClip doorSound;
        [SerializeField] [Range(0f, 1f)] private float effectsVolume = 1f;
        [SerializeField] [Range(0f, 1f)] private float speechVolume = 1f;
        
        private Customer _currentCustomer;
        private int _currentCustomerIndex;
        private float _currentBalance;
        private bool _isProcessingRound;
        
        public static event Action<Item> OnRoundChanged; 
        
        
        void Start()
        { 
            _currentBalance = 0f;
            _currentCustomerIndex = 0;
            _isProcessingRound = true;
            itemShell.HideItem();
            claimText.text = "";
            UpdateBalanceUI();
            StartCoroutine(LoadNextCustomerRoutine());
        }

        private void UpdateBalanceUI()
        {
            balanceText.text = $"{_currentBalance}$";
        }

        private void HandleProfitUI()
        {
            float profit = _currentCustomer.Item.RealPrice - _currentCustomer.Item.CustomerClaim.AskingPrice;
            potentialProfitText.text = $"+{profit}$";
        }
        
        
        private IEnumerator LoadNextCustomerRoutine()
        {
            if (_currentCustomerIndex >= customers.Count)
            {
                HandleFinishResult();
                yield break;
            }
            PlaySoundFX(doorSound);
            _currentCustomer = customers[_currentCustomerIndex];
            customerShell.SetupCustomer(_currentCustomer.CustomerSprite);
            yield return StartCoroutine(customerShell.SlideInRoutine());
            itemShell.SetupItem(_currentCustomer.Item);
            OnRoundChanged?.Invoke(_currentCustomer.Item);
            HandleProfitUI();
            StartCustomerSpeech(_currentCustomer.VoiceSound);
            string textToType = _currentCustomer.Item.CustomerClaim.CustomerText; 
            yield return StartCoroutine(TypeTextRoutine(textToType));
            StopCustomerSpeech();
            _isProcessingRound = false; 
        }

        

        private IEnumerator TypeTextRoutine(string text)
        {
            claimText.text = ""; 
            foreach (char letter in text.ToCharArray())
            {
                claimText.text += letter;
                yield return new WaitForSeconds(typingDelay); 
            }
        }
        
        private IEnumerator ProcessDecisionRoutine(bool isAccepted)
        {
            itemShell.HideItem();
            claimText.text = "";
            Item currentItem = _currentCustomer.Item;
            
            if (isAccepted)
            {
                float profit = currentItem.RealPrice - currentItem.CustomerClaim.AskingPrice;

                if (currentItem.IsAuthentic)
                {
                    _currentBalance += profit;

                    PlaySoundFX(profit > 0 ? winMoneySound : loseMoneySound);
                }
                else
                {
                    _currentBalance -= currentItem.CustomerClaim.AskingPrice;
                    PlaySoundFX(loseMoneySound);
                }
                UpdateBalanceUI();
            }
            else
            {
                PlaySoundFX(loseMoneySound);
            }
            
            yield return StartCoroutine(customerShell.SlideOutRoutine());
            _currentCustomerIndex++;
            yield return StartCoroutine(LoadNextCustomerRoutine());
        }
        
        

        private void HandleFinishResult()
        {

            if (_currentBalance >= quota)
            {
                winPanel.SetActive(true); 
            }
            else
            {
                losePanel.SetActive(true);
            }
        }


        private void CheckRound(bool isAccepted)
        {
            if (_isProcessingRound) return;
            _isProcessingRound = true;
            StartCoroutine(ProcessDecisionRoutine(isAccepted));
        }
        
        
        private void StartCustomerSpeech(AudioClip currentCustomerVoiceSound)
        {
            if (SoundFXManager.Instance && currentCustomerVoiceSound)
            {
                SoundFXManager.Instance.PlaySpeech(currentCustomerVoiceSound, speechVolume);
            }
        }
        
        private void StopCustomerSpeech()
        {
            if (SoundFXManager.Instance)
            {
                SoundFXManager.Instance.StopSpeech();
            }
        }

        
        
        private void PlaySoundFX(AudioClip clip)
        {
            if (SoundFXManager.Instance && clip)
            {
                SoundFXManager.Instance.PlaySoundFXClip(clip, transform, effectsVolume);
            }
        }
        
        
        
        
        private void OnEnable()
        {
            WindowButtons.OnDecisionMade += CheckRound;
        }

        

        private void OnDisable()
        {
            WindowButtons.OnDecisionMade -= CheckRound;
        }

        
    }
}

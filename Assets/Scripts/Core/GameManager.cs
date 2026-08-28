using System.Collections;
using System.Collections.Generic;
using AntiqueShop.Buttons;
using AntiqueShop.Items;
using AntiqueShop.UI;
using AntiqueShop.Utils;
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
        [SerializeField] private CurrentItem itemHolder;
        [SerializeField] private float typingDelay;
        
        [Header("End Game Panels")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        
        private Customer _currentCustomer;
        private int _currentCustomerIndex;
        private float _currentBalance;
        private bool _isProcessingRound;
        
        
        void Start()
        { 
            _currentBalance = 0f;
            _currentCustomerIndex = 0;
            _isProcessingRound = true;
            itemShell.HideItem();
            itemHolder.Set(null);
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

            _currentCustomer = customers[_currentCustomerIndex];
            customerShell.SetupCustomer(_currentCustomer.CustomerSprite);
            yield return StartCoroutine(customerShell.SlideInRoutine());
            itemShell.SetupItem(_currentCustomer.Item);
            itemHolder.Set(_currentCustomer.Item);
            HandleProfitUI();
            string textToType = _currentCustomer.Item.CustomerClaim.CustomerText; 
            yield return StartCoroutine(TypeTextRoutine(textToType));
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
            itemHolder.Set(null);
            claimText.text = "";
            Item currentItem = _currentCustomer.Item;
            
            if (isAccepted)
            {
                if (currentItem.IsAuthentic)
                {
                    _currentBalance += currentItem.RealPrice - currentItem.CustomerClaim.AskingPrice;
                }
                else
                {
                    _currentBalance -= currentItem.CustomerClaim.AskingPrice;
                }
                UpdateBalanceUI();
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

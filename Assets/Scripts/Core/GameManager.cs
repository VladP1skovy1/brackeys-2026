using System;
using System.Collections.Generic;
using AntiqueShop.Items;
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
        
        [Header("End Game Panels")]
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        
        private Customer _currentCustomer;
        private int _currentCustomerIndex;
        private float _currentBalance;
        
        
        void Start()
        { 
            _currentBalance = 0f;
            _currentCustomerIndex = 0;
            UpdateBalanceUI();
            HandleNextCustomer();
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

        private void HandleNextCustomer()
        {
            if (_currentCustomerIndex >= customers.Count)
            {
                HandleFinishResult();
                return;
            }
            _currentCustomer = customers[_currentCustomerIndex];
            customerShell.SetupCustomer(_currentCustomer.CustomerSprite);
            itemShell.SetupItem(_currentCustomer.Item);
            HandleProfitUI();

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
            
            _currentCustomerIndex++;
            HandleNextCustomer();
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

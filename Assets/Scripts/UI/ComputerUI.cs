using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AntiqueShop.UI
{
    public class ComputerUI : MonoBehaviour
    {
        [SerializeField] private GameObject computerCanvas;
        
        [SerializeField] private GameObject[] pages;
        [SerializeField] private Button[] buttons;
        
        [SerializeField] private Button closeButton;

        [SerializeField] private Color buttonColor;
        [SerializeField] private Color textColor;
        [SerializeField] private Color activeButtonColor;
        [SerializeField] private Color activeTextColor;

        private void OnEnable()
        {
            OpenTab(0);
        }

        private void Start()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i;
                buttons[i].onClick.AddListener(() => OpenTab(index));
            }
            
            if (closeButton != null)
            {
                closeButton.onClick.AddListener(CloseComputerUI);
            }
        }


        private void OpenTab(int tabIndex)
        {
            for (int i = 0; i < pages.Length; i++)
            {
                if (pages[i] != null)
                {
                    pages[i].SetActive(i == tabIndex);
                }
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                SetButtonVisual(buttons[i], i == tabIndex);
            }
        }

        private void SetButtonVisual(Button button, bool isActive)
        {
            if (button == null) return;
            Image bgImage = button.GetComponent<Image>();
            if (bgImage == null) return;
            bgImage.color = isActive ? activeButtonColor : buttonColor;
            TMP_Text txt = button.GetComponentInChildren<TMP_Text>();
            if (txt == null) return;
            txt.color = isActive ? activeTextColor : textColor;
        }

        private void CloseComputerUI()
        {
            if (computerCanvas == null) return;
            computerCanvas.SetActive(false);
        }
    }
}
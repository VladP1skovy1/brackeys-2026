using AntiqueShop.Core;
using UnityEngine;
using UnityEngine.UI;

namespace AntiqueShop.Utils
{
    public class SoundSettings : MonoBehaviour
    {
        [Header("Volume Sliders")] [SerializeField]
        private Slider masterSlider;

        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;

        private void Start()
        {
            SetupSliders();
        }

        private void SetupSliders()
        {
            SetupSlider(masterSlider, "MasterVolume", (v) => SoundMixerManager.Instance?.SetMasterVolume(v));
            SetupSlider(musicSlider, "MusicVolume", (v) => SoundMixerManager.Instance?.SetMusicVolume(v));
            SetupSlider(sfxSlider, "SoundFXVolume", (v) => SoundMixerManager.Instance?.SetSoundFXVolume(v));
        }

        private void SetupSlider(Slider slider, string prefName, System.Action<float> onValueChangedAction)
        {
            if (slider == null) return;

            float savedValue = PlayerPrefs.GetFloat(prefName, 1f);
            slider.value = savedValue;
            onValueChangedAction?.Invoke(savedValue);

            slider.onValueChanged.RemoveAllListeners();
            slider.onValueChanged.AddListener((value) =>
            {
                onValueChangedAction?.Invoke(value);
                PlayerPrefs.SetFloat(prefName, value);
                PlayerPrefs.Save();
            });
        }
    }
}
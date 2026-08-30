using UnityEngine;
using UnityEngine.Audio;

namespace AntiqueShop.Core
{
    public class SoundMixerManager : MonoBehaviour
    {
        public static SoundMixerManager Instance;

        [SerializeField] private AudioMixer audioMixer;

        private void Awake()
        {
            if (!Instance)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetMasterVolume(float volume)
        {
            audioMixer.SetFloat("masterVolume", Mathf.Log10(volume) * 20f);
        }

        public void SetMusicVolume(float volume)
        {
            audioMixer.SetFloat("musicVolume", Mathf.Log10(volume) * 20f);
        }

        public void SetSoundFXVolume(float volume)
        {
            audioMixer.SetFloat("soundFXVolume", Mathf.Log10(volume) * 20f);
        }
    }
}
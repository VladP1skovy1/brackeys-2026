using UnityEngine;

namespace AntiqueShop.Core
{
    public class SoundFXManager : MonoBehaviour
    {
        public static SoundFXManager Instance;
        
        [SerializeField] private AudioSource soundFXSource;
        [SerializeField] private AudioSource speechSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        
        public void PlaySoundFXClip(AudioClip clip, Transform spawnTransform, float volume)
        {
            if (!clip) return;
            AudioSource audioSource = Instantiate(soundFXSource, spawnTransform.position, Quaternion.identity, transform);
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.Play();
            float clipLength = audioSource.clip.length;
            Destroy(audioSource.gameObject, clipLength);
        }
        
        public void PlaySpeech(AudioClip clip, float volume)
        {
            if (!clip || !speechSource) return;
            
            speechSource.clip = clip;
            speechSource.volume = volume;
            speechSource.loop = true;
            speechSource.Play();
        }

        public void StopSpeech()
        {
            if (speechSource && speechSource.isPlaying)
            {
                speechSource.Stop();
            }
        }
    }
}

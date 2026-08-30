using UnityEngine;

namespace AntiqueShop.Core
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager _instance;

        private void Awake()
        {
            if (!_instance)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

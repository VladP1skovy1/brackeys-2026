using System.Collections;
using UnityEngine;

namespace AntiqueShop.UI
{
    public class CustomerUI : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        [Header("Movement Positions")]
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform centerPoint;
        [SerializeField] private Transform exitPoint;
        
        [Header("Animation Settings")]
        [SerializeField] private float moveDuration;
        [SerializeField] private AnimationCurve moveCurve;
        
        public void SetupCustomer(Sprite newSprite)
        {
            spriteRenderer.sprite = newSprite;
            transform.position = spawnPoint.position;
            gameObject.SetActive(true);
        }
        
        private IEnumerator MoveToPosition(Vector3 targetPosition)
        {
            Vector3 startPosition = transform.position;
            float elapsedTime = 0f;
            while (elapsedTime < moveDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / moveDuration;
                float curveValue = moveCurve.Evaluate(t);
                transform.position = Vector3.LerpUnclamped(startPosition, targetPosition, curveValue);
                yield return null;
            }
            transform.position = targetPosition; 
        }
        
        public IEnumerator SlideInRoutine()
        {
            transform.position = spawnPoint.position;
            yield return MoveToPosition(centerPoint.position);
        }

        public IEnumerator SlideOutRoutine()
        {
            yield return MoveToPosition(exitPoint.position);
        }
    }
}

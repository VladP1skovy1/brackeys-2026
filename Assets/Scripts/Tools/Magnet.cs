using System;
using System.Collections;
using AntiqueShop.Items;
using AntiqueShop.UI;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Magnet : Tool
    {
        
        [SerializeField] private Sprite idleSprite;
        [SerializeField] private Sprite activeSprite;
        [SerializeField] private Transform inspectPoint;
        [SerializeField] private Transform itemInspectPoint;
        
        [SerializeField] private float pullDuration;
        [SerializeField] private float waitBeforePullDuration;
        [SerializeField] private float attachedWaitDuration;
        [SerializeField] private float failWaitDuration;
        [SerializeField] private AnimationCurve pullCurve;
        
        [SerializeField] private ItemUI itemUI;
        
        private SpriteRenderer _spriteRenderer;
        private Transform _itemTransform;
        private Vector3 _magnetOriginalPos;
        private Vector3 _itemOriginalPos;
        private bool _isProcessing;


        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _magnetOriginalPos = transform.position;
        }

        private void Start()
        {
            _itemTransform = itemUI.transform;
            _itemOriginalPos = _itemTransform.position;
        }

        protected override void OnToolClick()
        {
            if (_isProcessing || !itemUI.IsActive) return;

            StartCoroutine(MagnetSequenceRoutine());
        }
        
        private IEnumerator MagnetSequenceRoutine()
        {
            _isProcessing = true;
            _spriteRenderer.sprite = activeSprite;
            transform.position = inspectPoint.position;
            
            yield return new WaitForSeconds(waitBeforePullDuration);

            if (CurrentItem is IMagnetic { IsMagnetic: true })
            {
                
                float timePassed = 0f;

                while (timePassed < pullDuration)
                {
                    timePassed += Time.deltaTime;
                    float pullProgress = pullCurve.Evaluate(timePassed / pullDuration);
                    _itemTransform.position = Vector3.LerpUnclamped(_itemOriginalPos, itemInspectPoint.position, pullProgress);
                    yield return null;
                }

                yield return new WaitForSeconds(attachedWaitDuration);
                _itemTransform.position = _itemOriginalPos; 
            }
            else
            {
                yield return new WaitForSeconds(failWaitDuration);
            }
            
            transform.position = _magnetOriginalPos;
            _spriteRenderer.sprite = idleSprite;
            
            _isProcessing = false;
        }
    }
}

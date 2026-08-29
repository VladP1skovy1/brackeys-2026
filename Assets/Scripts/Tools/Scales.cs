using System.Collections;
using AntiqueShop.Items;
using AntiqueShop.UI;
using UnityEngine;

namespace AntiqueShop.Tools
{
    public class Scales : Tool
    {
        [SerializeField] private Transform itemInspectPoint;

        [SerializeField] private float waitBeforeLiftDuration;
        [SerializeField] private float liftDuration;
        [SerializeField] private float weighedWaitDuration;
        [SerializeField] private AnimationCurve liftCurve;

        [SerializeField] private ItemUI itemUI;
        [SerializeField] private ToolReadout readout;
        [SerializeField] private string noWeightText = "---";

        private Transform _itemTransform;
        private Vector3 _itemOriginalPos;
        private bool _isProcessing;

        private void Start()
        {
            _itemTransform = itemUI.transform;
            _itemOriginalPos = _itemTransform.position;
        }

        protected override void OnToolClick()
        {
            if (_isProcessing || !itemUI.IsActive) return;

            StartCoroutine(WeighSequenceRoutine());
        }

        private IEnumerator WeighSequenceRoutine()
        {
            _isProcessing = true;

            yield return new WaitForSeconds(waitBeforeLiftDuration);
            yield return MoveItemRoutine(_itemOriginalPos, itemInspectPoint.position);

            readout.Show(CurrentItem is IWeighable weighable
                ? $"{weighable.Weight:0.##} g"
                : noWeightText);

            yield return new WaitForSeconds(weighedWaitDuration);

            readout.Hide();
            yield return MoveItemRoutine(itemInspectPoint.position, _itemOriginalPos);

            _isProcessing = false;
        }

        private IEnumerator MoveItemRoutine(Vector3 from, Vector3 to)
        {
            float timePassed = 0f;

            while (timePassed < liftDuration)
            {
                timePassed += Time.deltaTime;
                float liftProgress = liftCurve.Evaluate(timePassed / liftDuration);
                _itemTransform.position = Vector3.LerpUnclamped(from, to, liftProgress);
                yield return null;
            }

            _itemTransform.position = to;
        }
    }
}

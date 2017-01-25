using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Undercurrent.Scripts.Ship
{
    public class Glint : MonoBehaviour
    {
        public Light Light;
        public float MinimumWait = 2;
        public float MaximumWait = 12;

        private void Start()
        {
            BeginCoroutine();
        }

        private IEnumerator GlintLight()
        {
            yield return new WaitForSeconds(Random.Range(MinimumWait, MaximumWait));

            DOTween.To(() => Light.intensity, x => Light.intensity = x, 0.75f, 3).SetEase(Ease.InSine).OnComplete(EaseOut);
        }

        private void EaseOut()
        {
            DOTween.To(() => Light.intensity, x => Light.intensity = x, 0, 2).SetEase(Ease.OutSine).OnComplete(BeginCoroutine);
        }

        private void BeginCoroutine()
        {
            StartCoroutine(GlintLight());
        }
    }
}

using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Presentations.Ui
{
    public class CurtainView : View, ISelfValidator
    {
        [Required] [SerializeField] 
        private CanvasGroup _canvasGroup;

        [SerializeField] private float _duration = 1;
        
        public void Validate(SelfValidationResult result)
        {
            if (_duration <= 0)
            {
                result.AddError($"{nameof(_duration)} is zero");
            }
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);

            _canvasGroup.alpha = 0;
        }

        public async UniTask ShowCurtain()
        {
            Show();

            await Fade(0, 1);
        }
        
        public async UniTask HideCurtain()
        {
            await Fade(1, 0);

            Hide();
        }

        private async UniTask Fade(float startAlpha, float endAlpha)
        {
            _canvasGroup.alpha = startAlpha;

            while (Mathf.Abs(_canvasGroup.alpha - endAlpha) > 0.01f)
            {
                _canvasGroup.alpha = Mathf.MoveTowards(
                    _canvasGroup.alpha, endAlpha, Time.deltaTime / _duration);

                await UniTask.Yield();
            }

            _canvasGroup.alpha = endAlpha;
        }
    }
}
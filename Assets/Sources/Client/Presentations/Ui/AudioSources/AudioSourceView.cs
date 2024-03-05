using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sources.Client.Presentations.Views;
using Sources.Client.Presentations.Views.ObjectPools;
using UnityEngine;

namespace Sources.Client.Presentations.Ui.AudioSources
{
    public class AudioSourceView : View, ISelfValidator
    {
        [Required] [SerializeField]
        private AudioSource _audioSource;

        public event Action AudioSourceStopPlaying;

        public void Validate(SelfValidationResult result)
        {
            if (_audioSource.playOnAwake)
            {
                result.AddError($"{nameof(AudioSource)} playOnAwake true");
            }
        }

        public void ReturnToPool()
        {
            if(gameObject.TryGetComponent(out PoolableObject poolableObject) == false)
                return;
            
            poolableObject.ReturnToPool();
        }

        public void SetClip(AudioClip audioClip)
        {
            _audioSource.clip = audioClip 
                ? audioClip : throw new NullReferenceException(nameof(audioClip));
        }
        
        public void Play() => 
            _audioSource.Play();

        public void Stop() => 
            _audioSource.Stop();

        public async void PlayAsync()
        {
            Play();

            await InvokeStopCallback();
            
            ReturnToPool();
        }

        public void Pause() => 
            _audioSource.Pause();

        public void UnPause() => 
            _audioSource.UnPause();

        public void SetLoop() => 
            _audioSource.loop = true;

        public void UnLoop() => 
            _audioSource.loop = false;

        public void SetVolume(float volume) => 
            _audioSource.volume = volume;

        public async UniTask InvokeStopCallback()
        {
            while (_audioSource.isPlaying)
            {
                UniTask.Yield();
            }
            
            AudioSourceStopPlaying?.Invoke();
        }
    }
}
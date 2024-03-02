using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Presentations.Ui.AudioSources
{
    public class AudioSourceView : View, ISelfValidator
    {
        [Required] [SerializeField]
        private AudioSource _audioSource;

        public void Play() => 
            _audioSource.Play();

        public void Stop() => 
            _audioSource.Stop();

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

        //TODO перенести это в отдельный валидатор
        public void Validate(SelfValidationResult result)
        {
            if (_audioSource.clip == null)
            {
                result.AddError($"{nameof(AudioSource)} not set AudioClip");
            }
        }
    }
}
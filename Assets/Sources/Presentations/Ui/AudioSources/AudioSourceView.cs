using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Presentations.Ui.AudioSources
{
    //Todo добавить валидатор
    public class AudioSourceView : View
    {
        [SerializeField] private AudioSource _audioSource;

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

    }
}
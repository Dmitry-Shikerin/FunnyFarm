using System;
using System.Collections.Generic;
using Sources.Domain.Sounds;
using Sources.InfrastructureInterfaces.Services.SoundServices;
using Sources.Presentations.Containers.Ui;
using Sources.Presentations.Ui.AudioSources;
using UnityEngine;

namespace Sources.Infrastructure.Services.SoundServices
{
    public class SoundService : ISoundService
    {
        private Dictionary<SoundType, AudioSourceView> _audioSourceViews;

        public SoundService(GameplayHud hud)
        {
            _audioSourceViews = hud.AudioSources ??
                                throw new NullReferenceException(nameof(hud.AudioSources));
        }

        //TODO сюда добавится логика паузы и изменения громкости 

        public void Stop(SoundType sound)
        {
            if (_audioSourceViews.ContainsKey(sound) == false)
                throw new InvalidOperationException(nameof(sound));

            _audioSourceViews[sound].Stop();
        }

        public void Play(SoundType sound)
        {
            if (_audioSourceViews.ContainsKey(sound) == false)
                throw new InvalidOperationException(nameof(sound));

            _audioSourceViews[sound].Play();
        }

        public void Pause(SoundType sound)
        {
            if (_audioSourceViews.ContainsKey(sound) == false)
                throw new InvalidOperationException(nameof(sound));

            _audioSourceViews[sound].Pause();
        }

        public void UnPause(SoundType sound)
        {
            if (_audioSourceViews.ContainsKey(sound) == false)
                throw new InvalidOperationException(nameof(sound));

            _audioSourceViews[sound].UnPause();
        }

        public void SetVolume(SoundType sound, float volume)
        {
            if (_audioSourceViews.ContainsKey(sound) == false)
                throw new InvalidOperationException(nameof(sound));

            volume = Mathf.Clamp(volume, 0, 1);

            _audioSourceViews[sound].SetVolume(volume);
        }

        public void SetLoop(SoundType sound)
        {
            if (_audioSourceViews.ContainsKey(sound) == false)
                throw new InvalidOperationException(nameof(sound));

            _audioSourceViews[sound].SetLoop();
        }

        public void UnLoop(SoundType sound)
        {
            if (_audioSourceViews.ContainsKey(sound) == false)
                throw new InvalidOperationException(nameof(sound));

            _audioSourceViews[sound].UnLoop();
        }
    }
}
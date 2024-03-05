using System;
using System.Collections.Generic;
using Sources.Client.Domain.Sounds;
using Sources.Client.Infrastructure.Services.ObjectPools;
using Sources.Client.Presentations.Containers.Ui;
using Sources.Client.Presentations.Ui.AudioSources;
using Sources.Domain.Sounds;
using Sources.InfrastructureInterfaces.Services.SoundServices;
using UnityEngine;

namespace Sources.Client.Infrastructure.Services.SoundServices
{
    public class SoundService : ISoundService
    {
        private Dictionary<SoundType, AudioSourceView> _audioSourceViews;
        private Dictionary<SoundType, AudioClip> _audioClips;
        private ObjectPool<AudioSourceView> _objectPool;

        public SoundService(GameplayHud hud, GameSounds gameSounds)
        {
            _audioSourceViews = hud.AudioSources ??
                                throw new NullReferenceException(nameof(hud.AudioSources));
            _objectPool = new ObjectPool<AudioSourceView>(hud.AudioSourcesParentContainerView.transform);
            _audioClips = gameSounds.AudioClips ?? 
                          throw new NullReferenceException(nameof(gameSounds.AudioClips));
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
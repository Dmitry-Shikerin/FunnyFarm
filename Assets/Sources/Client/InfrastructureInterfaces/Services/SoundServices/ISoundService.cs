using Sources.Domain.Sounds;

namespace Sources.InfrastructureInterfaces.Services.SoundServices
{
    public interface ISoundService
    {
        void Stop(SoundType sound);
        void Play(SoundType sound);
        void Pause(SoundType sound);
        void UnPause(SoundType sound);
        void SetVolume(SoundType sound, float volume);
        void SetLoop(SoundType sound);
        void UnLoop(SoundType sound);
    }
}
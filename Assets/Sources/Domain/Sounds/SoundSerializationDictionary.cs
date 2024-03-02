using System;
using Sources.Presentations.Ui.AudioSources;
using Sources.Utils.Serializations;

namespace Sources.Domain.Sounds
{
    [Serializable]
    public class SoundSerializationDictionary : UnitySerializationDictionary<SoundType, AudioSourceView>
    {
    }
}
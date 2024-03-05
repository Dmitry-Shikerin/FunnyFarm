using System;
using Sources.Client.Presentations.Ui.AudioSources;
using Sources.Utils.Serializations;

namespace Sources.Domain.Sounds
{
    [Serializable]
    public class AudioSorceViewSerializationDictionary : UnitySerializationDictionary<SoundType, AudioSourceView>
    {
    }
}
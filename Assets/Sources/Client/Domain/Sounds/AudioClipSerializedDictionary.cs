using System;
using Sources.Domain.Sounds;
using Sources.Utils.Serializations;
using UnityEngine;

namespace Sources.Client.Domain.Sounds
{
    [Serializable]
    public class AudioClipSerializedDictionary : UnitySerializationDictionary<SoundType, AudioClip>
    {
    }
}
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Domain.Sounds;
using UnityEngine;

namespace Sources.Client.Domain.Sounds
{
    [CreateAssetMenu(fileName = "GameSounds", 
        menuName = "Containers/GameSounds", order = 51)]
    public class GameSounds : ScriptableObject
    {
        [SerializeField] private AudioClipSerializedDictionary _audioClips;

        public AudioClipSerializedDictionary AudioClips => _audioClips;
    }
}
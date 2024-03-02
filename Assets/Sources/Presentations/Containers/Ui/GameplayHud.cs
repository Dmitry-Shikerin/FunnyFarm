using Sirenix.OdinInspector;
using Sources.Domain.Sounds;
using Sources.Presentations.Ui.AudioSources;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Presentations.Containers.Ui
{
    //TODO добавить валидатор
    public class GameplayHud : View
    {
        [Button(ButtonSizes.Large)] [FoldoutGroup("AudioSources")] [Required]
        public SoundSerializationDictionary _audioSources;
        
        public SoundSerializationDictionary AudioSources => _audioSources;
        
    }
}
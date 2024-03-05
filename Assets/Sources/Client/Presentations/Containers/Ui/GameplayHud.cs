using Sirenix.OdinInspector;
using Sources.Client.Presentations.Views;
using Sources.Domain.Sounds;
using UnityEngine;

namespace Sources.Client.Presentations.Containers.Ui
{
    //TODO добавить валидатор
    public class GameplayHud : View
    {
        [Button(ButtonSizes.Large)] [FoldoutGroup("AudioSources")] [Required] [SerializeField]
        private AudioSorceViewSerializationDictionary _audioSources;

        [FoldoutGroup("AudioSources")] [Required] [SerializeField]
        private AudioSourcesParentContainerView _audioSourcesParentContainerView;
        
        public AudioSorceViewSerializationDictionary AudioSources => _audioSources;
        public AudioSourcesParentContainerView AudioSourcesParentContainerView => _audioSourcesParentContainerView;
    }
}
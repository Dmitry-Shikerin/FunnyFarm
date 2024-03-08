using Sirenix.OdinInspector;
using Sources.Client.Presentations.Views;
using Sources.Client.Presentations.Views.Uis.Forms.Gameplay;
using Sources.Domain.Sounds;
using UnityEngine;

namespace Sources.Client.Presentations.Containers.Ui
{
    public class GameplayHud : View
    {
        [Button(ButtonSizes.Large)] [FoldoutGroup("AudioSources")] [Required] [SerializeField]
        private AudioSorceViewSerializationDictionary _audioSources;
        [FoldoutGroup("AudioSources")] [Required] [SerializeField]
        private AudioSourcesParentContainerView _audioSourcesParentContainerView;
        
        [Button(ButtonSizes.Large)] [FoldoutGroup("FormBindableViews")] [Required] [SerializeField]
        private HudFormBindableView _hudFormBindableView;

        [FoldoutGroup("FormBindableViews")] [Required] [SerializeField]
        private PauseFormBindableView _pauseFormBindableView;

        public AudioSorceViewSerializationDictionary AudioSources => _audioSources;
        public AudioSourcesParentContainerView AudioSourcesParentContainerView => _audioSourcesParentContainerView;
        
        public HudFormBindableView HudFormBindableView => _hudFormBindableView;
        public PauseFormBindableView PauseFormBindableView => _pauseFormBindableView;
    }
}
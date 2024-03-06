using Sirenix.OdinInspector;
using Sources.Client.PresentationsInterfaces.Binds.CharacterControllers;
using Sources.Frameworks.MVVM.Domain.Properties;
using UnityEngine;

namespace Sources.Client.Presentations.Binds.CharacterControllers
{
    public class CharacterControllerMovePropertyBind : BindableViewProperty<Vector3>,
        ICharacterControllerMovePropertyBind
    {
        [Required][SerializeField] private CharacterController _characterController;
        
        public override Vector3 BindableProperty
        {
            get => transform.position;
            set => _characterController.Move(value);
        }
    }
}
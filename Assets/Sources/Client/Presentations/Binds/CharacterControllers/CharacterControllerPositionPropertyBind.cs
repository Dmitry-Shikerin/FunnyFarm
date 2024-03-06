using Sirenix.OdinInspector;
using Sources.Client.PresentationsInterfaces.Binds.CharacterControllers;
using Sources.Frameworks.MVVM.Domain.Properties;
using UnityEngine;

namespace Sources.Client.Presentations.Binds.CharacterControllers
{
    public class CharacterControllerPositionPropertyBind : BindableViewProperty<Vector3>,
        ICharacterControllerPositionPropertyBind
    {
        [Required] [SerializeField] private CharacterController _characterController;

        private Transform _transform;

        //TODO зачем тут так делается?
        private Transform Transform => _transform ??= _characterController.GetComponent<Transform>();
        
        //TODO на гет пустое полу
        public override Vector3 BindableProperty
        {
            get => _transform.position;
            set
            {
                _characterController.enabled = false;
                Transform.position = value;
                _characterController.enabled = true;
            }
        }
    }
}
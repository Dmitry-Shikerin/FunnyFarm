using Sirenix.OdinInspector;
using Sources.Client.PresentationsInterfaces.Binds.Rotations;
using Sources.Frameworks.MVVM.Domain.Properties;
using UnityEngine;

namespace Sources.Client.Presentations.Binds.Rotations
{
    public class LookDirectionPropertyBind : BindableViewProperty<Vector3>, ILookDirectionPropertyBind
    {
        [Required] [SerializeField] private Transform _transform;

        public override Vector3 BindableProperty
        {
            get => _transform.forward;
            set => _transform.forward = value;
        }
    }
}
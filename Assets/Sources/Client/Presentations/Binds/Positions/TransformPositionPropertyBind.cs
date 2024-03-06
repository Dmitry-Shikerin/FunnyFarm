using Sources.Client.PresentationsInterfaces.Binds.Positions;
using Sources.Frameworks.MVVM.Domain.Properties;
using UnityEngine;

namespace Sources.Client.Presentations.Binds.Positions
{
    public class TransformPositionPropertyBind : BindableViewProperty<Vector3>, ITransformPositionPropertyBind
    {
        public override Vector3 BindableProperty
        {
            get => transform.position;
            set => transform.position = value;
        }
    }
}
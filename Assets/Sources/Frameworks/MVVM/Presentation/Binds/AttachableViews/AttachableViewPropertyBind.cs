using Sources.Frameworks.MVVM.Domain.Properties;
using Sources.Frameworks.MVVM.PresentationInterfaces.Binds.AttachableView;
using Sources.Frameworks.MVVM.PresentationInterfaces.Views;
using UnityEngine;

namespace Sources.Frameworks.MVVM.Presentation.Binds.AttachableViews
{
    public class AttachableViewPropertyBind : BindableViewProperty<IAttachableView>, IAttachableView,
        IAttachableViewPropertyBind
    {
        public override IAttachableView BindableProperty
        {
            get => this;
            set { return; }
        }

        public void Attach(IBindableView bindableView) =>
            ((MonoBehaviour)bindableView).transform.SetParent(transform, false);
    }
}
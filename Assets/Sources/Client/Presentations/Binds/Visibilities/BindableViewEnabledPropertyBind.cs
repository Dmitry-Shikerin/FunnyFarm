using Sirenix.OdinInspector;
using Sources.Client.PresentationsInterfaces.Binds.Visibilities;
using Sources.Frameworks.MVVM.Domain.Properties;
using Sources.Frameworks.MVVM.Presentation.Views;
using UnityEngine;

namespace Sources.Client.Presentations.Binds.Visibilities
{
    public class BindableViewEnabledPropertyBind : BindableViewProperty<bool>,
        IBindableViewEnabledPropertyBind
    {
        [Required] [SerializeField] private BindableView _view;

        public override bool BindableProperty
        {
            get => _view.gameObject.activeSelf;
            set => _view.gameObject.SetActive(value);
        }
    }
}
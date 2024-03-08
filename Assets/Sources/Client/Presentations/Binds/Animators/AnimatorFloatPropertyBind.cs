using System;
using Sirenix.OdinInspector;
using Sources.Client.PresentationsInterfaces.Binds.Animators;
using Sources.Frameworks.MVVM.Domain.Properties;
using UnityEngine;

namespace Sources.Client.Presentations.Binds.Animators
{
    public class AnimatorFloatPropertyBind : BindableViewProperty<float>, 
        IAnimatorFloatPropertyBind, ISelfValidator
    {
        [Required][SerializeField] private Animator _animator;
        [SerializeField] private string _propertyName;

        private int _speedHash;

        public void Validate(SelfValidationResult result)
        {
            if (string.IsNullOrWhiteSpace(_propertyName))
            {
                result.AddError($"{_propertyName} is null or white spase");
            }
        }

        private void Awake() => 
            _speedHash = Animator.StringToHash(_propertyName);

        public override float BindableProperty
        {
            get => _animator.GetFloat(_speedHash);
            set => _animator.SetFloat(_speedHash, value);
        }
    }
}
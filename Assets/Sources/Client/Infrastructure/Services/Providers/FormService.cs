using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Client.DomainInterfaces.Ui.Forms;
using Sources.Client.InfrastructureInterfaces.Services.Providers;
using Sources.Client.UseCases.Common.Components.Visibilities.Commands;

namespace Sources.Client.Infrastructure.Services.Providers
{
    public class FormService : IFormService
    {
        private readonly HideCommand _hideCommand;
        private readonly ShowCommand _showCommand;
        private Dictionary<Type, int> _forms = new Dictionary<Type, int>();

        public FormService
        (
            HideCommand hideCommand,
            ShowCommand showCommand
        )
        {
            _hideCommand = hideCommand ?? throw new ArgumentNullException(nameof(hideCommand));
            _showCommand = showCommand ?? throw new ArgumentNullException(nameof(showCommand));
        }

        public void Show<T>() where T : IForm
        {
            if (_forms.ContainsKey(typeof(T)) == false)
                throw new NullReferenceException(nameof(T));

            int activeFormId = _forms[typeof(T)];

            _forms.Values
                .Except(new List<int>() { activeFormId })
                .ToList()
                .ForEach(formId => _hideCommand.Handle(formId));
            
            _showCommand.Handle(activeFormId);
        }

        public void Hide<T>() where T : IForm
        {
            if (_forms.ContainsKey(typeof(T)) == false)
                throw new NullReferenceException(nameof(T));

            int activeFormId = _forms[typeof(T)];
            
            if (activeFormId == default)
                throw new NullReferenceException(nameof(activeFormId));
            
            _hideCommand.Handle(activeFormId);
        }

        public void Register<T>(int id) where T : IForm
        {
            if (_forms.ContainsKey(typeof(T)))
                throw new InvalidOperationException(nameof(T));

            _forms[typeof(T)] = id;
        }

        public int Get<T>() where T : IForm
        {
            if (_forms.ContainsKey(typeof(T)) == false)
                throw new NullReferenceException(nameof(T));

            return _forms[typeof(T)];
        }
    }
}
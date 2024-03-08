using Sirenix.OdinInspector;
using Sources.Client.PresentationsInterfaces.Binds.Buttons;
using Sources.Frameworks.MVVM.Domain.Methods;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Client.Presentations.Binds.Buttons
{
    //TODO почему тут вектор3?
    public class ButtonClickMethodBind : BindableViewMethod<Vector3>, IButtonClickMethodBind
    {
        [Required][SerializeField] private Button _button;

        private void OnEnable() => 
            _button?.onClick.AddListener(OnButtonClick);

        private void OnDisable() => 
            _button?.onClick.RemoveListener(OnButtonClick);

        //TODO нужно ли оставлять Canvas на корневом обьекте?
        //TODO неприбиндился метод
        private void OnButtonClick() => 
            BindingCallback.Invoke(Input.mousePosition);
    }
}
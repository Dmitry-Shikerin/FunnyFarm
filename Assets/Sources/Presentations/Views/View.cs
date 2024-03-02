using Sources.PresentationsInterfaces.Views;
using UnityEngine;

namespace Sources.Presentations.Views
{
    public class View : MonoBehaviour, IView
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
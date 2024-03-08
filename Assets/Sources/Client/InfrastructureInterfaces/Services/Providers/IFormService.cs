using Sources.Client.Domain.Ui.Forms;
using Sources.Client.DomainInterfaces.Ui.Forms;

namespace Sources.Client.InfrastructureInterfaces.Services.Providers
{
    public interface IFormService
    {
        public void Show<T>() where T : IForm;
        public void Hide<T>() where T : IForm;
        public int Get<T>() where T : IForm;
    }
}
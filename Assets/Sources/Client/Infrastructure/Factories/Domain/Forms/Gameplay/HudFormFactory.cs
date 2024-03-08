using Sources.Client.Domain.Components;
using Sources.Client.Domain.Ui.Forms.Gameplay;
using Sources.Client.InfrastructureInterfaces.Factories.Domain.Forms.Gameplay;

namespace Sources.Client.Infrastructure.Factories.Domain.Forms.Gameplay
{
    public class HudFormFactory : IHudFormFactory
    {
        public HudForm Create(int id)
        {
            HudForm hudForm = new HudForm(id);
            
            hudForm.AddComponent(new VisibilityComponent(true));

            return hudForm;
        }
    }
}
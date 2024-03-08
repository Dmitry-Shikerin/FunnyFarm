using Sources.Client.Domain.Components;
using Sources.Client.Domain.Ui.Forms.Gameplay;
using Sources.Client.InfrastructureInterfaces.Factories.Domain.Forms.Gameplay;

namespace Sources.Client.Infrastructure.Factories.Domain.Forms.Gameplay
{
    public class PauseFormFactory : IPauseFormFactory
    {
        public PauseForm Create(int id)
        {
            PauseForm pauseForm = new PauseForm(id);
            
            pauseForm.AddComponent(new VisibilityComponent(false));

            return pauseForm;
        }
    }
}
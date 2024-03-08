using Sources.Client.Domain.Ui.Forms.Gameplay;

namespace Sources.Client.InfrastructureInterfaces.Factories.Domain.Forms.Gameplay
{
    public interface IPauseFormFactory
    {
        PauseForm Create(int id);
    }
}
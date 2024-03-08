using Sources.Client.Domain.Ui.Forms.Gameplay;

namespace Sources.Client.InfrastructureInterfaces.Factories.Domain.Forms.Gameplay
{
    //TODO возмможно обобщить все фабрики формочнек под одлин интерфейс с дженериком
    public interface IHudFormFactory
    {
        HudForm Create(int id);
    }
}
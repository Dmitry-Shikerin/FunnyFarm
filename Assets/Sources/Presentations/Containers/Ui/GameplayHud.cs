using Sources.Domain.Sounds;
using Sources.Presentations.Views;
using UnityEngine;

namespace Sources.Presentations.Containers.Ui
{
    //TODO добавить валидатор
    public class GameplayHud : View
    {
        [field: SerializeField] public SoundSerializationDictionary AudioSources { get; private set; }
    }
}
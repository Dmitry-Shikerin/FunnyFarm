using System.Reflection;
using Sources.Client.App.Core;
using Sources.Client.Infrastructure.Factories.App;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private AppCore _appCore;

    private void Awake()
    {
        _appCore = FindObjectOfType<AppCore>() ?? new AppCoreFactory().Create();
    }
}

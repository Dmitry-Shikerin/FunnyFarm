using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.App.Core;
using Sources.Client.Infrastructure.Factories.Scenes;
using Sources.Client.Infrastructure.Services.SceneService;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Domain.Constants;
using Sources.Infrastructure.Services.SceneLoaderService;
using Sources.Presentations.Ui;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Zenject;
using Object = UnityEngine.Object;

namespace Sources.Client.Infrastructure.Factories.App
{
    public class AppCoreFactory
    {
        public AppCore Create()
        {
            AppCore appCore = new GameObject(nameof(AppCore)).AddComponent<AppCore>();

            // CurtainView curtainView = 
            //     Object.Instantiate(Resources.Load<CurtainView>(PrefabPaths.Curtain)) ??
            //                           throw new NullReferenceException(nameof(CurtainView));

            // Dictionary<string, Func<object, LifetimeScope, UniTask<IScene>>> sceneStates =
            //     new Dictionary<string, Func<object, LifetimeScope, UniTask<IScene>>>();
            Dictionary<string, Func<object, SceneContext, UniTask<IScene>>> sceneStates =
                new Dictionary<string, Func<object, SceneContext, UniTask<IScene>>>();
            
            SceneService sceneService = new SceneService(sceneStates);

            // sceneStates[ScenName.Gameplay] = (payload, scope) =>
            //     scope.Container.Resolve<GameplaySceneFactory>().Create(payload);
            sceneStates[ScenName.Gameplay] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            
            // sceneService.AddBeforeSceneChangeHandler(async sceneName =>
            // {
            //     await curtainView.ShowCurtain();
            // });
            
            sceneService.AddBeforeSceneChangeHandler(async sceneName =>
                await new SceneLoaderService().Load(sceneName));
            
            // sceneService.AddAfterSceneChangeHandler(async () =>
            //     await UniTask.Delay(TimeSpan.FromSeconds(2f)));
            
            // sceneService.AddAfterSceneChangeHandler(async () =>
            // {
            //     await curtainView.HideCurtain();
            // });

            appCore.Construct(sceneService);
 

            return appCore;
        }
    }
}
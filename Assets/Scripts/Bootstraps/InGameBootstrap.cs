using System;
using UnityEngine;

public class InGameBootstrap : BaseBootstrap
{
    protected override void DI()
    {
        base.DI();
        // 필요한 Manager만 생성해서 Container에 등록
        Container.Register<ICameraManager>(new CameraManager(Container));
        Container.Register<IGameManager>(new GameManager(Container));
        Container.Register<IResourceManager>(new ResourceManager(Container));
    }

    private void Start()
    {
        // 게임 시작
        Container.Initialize();
        Container.Resolve<IGameManager>().StartGame();
    }

    private void OnDestroy()
    {
        Container.Dispose();
    }
}
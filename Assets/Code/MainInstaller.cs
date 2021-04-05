using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IQuoteSource>()
            .To<RandomQuoteSource>()
            .FromNewComponentOnNewGameObject()
            .AsSingle();

        Container.Bind<TestViewModel>()
            .AsSingle();
    }
}

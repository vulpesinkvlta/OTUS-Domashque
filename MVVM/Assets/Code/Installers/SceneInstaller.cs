using Lessons;
using Lessons.Architecture.PM;
using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerDataConfig _playerConfig;

    public override void InstallBindings()
    {
        Container.Bind<PlayerDataConfig>().FromInstance(_playerConfig).AsSingle();

        //Container.Bind<PlayerFacade>().AsSingle();
        //Container.Bind<PlayerFactory>().AsSingle();
        //Container.Bind<CharacterPopupViewModelFactory>().AsSingle();
        new CharacterInstaller(Container);
    }
}
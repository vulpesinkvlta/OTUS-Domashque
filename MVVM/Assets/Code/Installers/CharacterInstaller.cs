using Lessons.Architecture.PM;
using Zenject;

namespace Lessons
{
    public class CharacterInstaller
    {
        public CharacterInstaller(DiContainer container)
        {
            container.Bind<UserInfo>().AsSingle().NonLazy();
            container.Bind<CharacterInfo>().AsSingle().NonLazy();
            container.Bind<PlayerLevel>().AsSingle().NonLazy();
            container.Bind<PlayerFactory>().AsSingle().NonLazy();
            container.Bind<CharacterPopupViewModelFactory>().AsSingle().NonLazy(); 
            container.Bind<PlayerFacade>().AsSingle().NonLazy();
        }
    }
}

using Assets.Code.Character;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterHelper : MonoBehaviour
    {
        [SerializeField] private PlayerDataConfig _playerConfig;

        [SerializeField] private CharacterPopupView _characterPopup;

        private PlayerFacade _player;
        private CharacterPopupViewModel _popupVM;

        private PlayerFactory _playerFactory;
        private CharacterPopupViewModelFactory _characterVMFactory;

        [Inject]
        private void Construct(PlayerFactory playerFactory,
                               CharacterPopupViewModelFactory characterVMFactory,
                               PlayerFacade playerFacade)
        {
            _playerFactory = playerFactory; 
            _characterVMFactory = characterVMFactory;
            _player = playerFacade;
        }

        public void ShowCharacterPopup()
        {
            _player = _playerFactory.Create(_playerConfig);
            _popupVM = _characterVMFactory.Create(_player);
            _characterPopup.Show(_popupVM);
        }

        [ContextMenu("Add 25 XP")]
        public void AddExp25()
        {
            _player.Level.AddExperience(25);
        }

        [ContextMenu("Level Up")]
        public void LevelUp()
        {
            _player.Level.LevelUp();
        }
    }
}
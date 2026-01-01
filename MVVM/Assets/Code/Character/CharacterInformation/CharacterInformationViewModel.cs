using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class CharacterInformationViewModel : ICharacterInformationViewModel, IDisposable
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Sprite Icon { get; private set; }

        public event Action OnInformationChanged;

        private readonly UserInfo _userInfo;

        public CharacterInformationViewModel(UserInfo userInfo)
        {
            _userInfo = userInfo;
            _userInfo.OnNameChanged += OnNameChanged;
            _userInfo.OnDescriptionChanged += OnDescriptionChanged;
            _userInfo.OnIconChanged += OnIconChanged;

            UpdateAll();
        }

        private void UpdateAll()
        {
            Name = _userInfo.Name;
            Description = _userInfo.Description;
            Icon = _userInfo.Icon;  
        }

        private void OnNameChanged(string name)
        {
            Name = name;
            OnInformationChanged?.Invoke();
        }


        private void OnDescriptionChanged(string description)
        {
            Description = description;
            OnInformationChanged?.Invoke();
        }
        private void OnIconChanged(Sprite icon)
        {
            Icon = icon;
            OnInformationChanged?.Invoke();
        }

        public void Dispose()
        {
            _userInfo.OnNameChanged -= OnNameChanged;
            _userInfo.OnDescriptionChanged -= OnDescriptionChanged;
            _userInfo.OnIconChanged -= OnIconChanged;
        }
    }   
}
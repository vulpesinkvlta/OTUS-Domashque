using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
        public class CharacterInformationView : MonoBehaviour, IDisposable
        {
            [SerializeField] private TMP_Text _name;
            [SerializeField] private TMP_Text _description;
            [SerializeField] private Image _playerIcon;

            private ICharacterInformationViewModel _viewModel;
        
            public void Bind(ICharacterInformationViewModel viewModel)
            {
                _viewModel = viewModel;
                _viewModel.OnInformationChanged += UpdateUI;
                UpdateUI();
            }


        private void UpdateUI()
            {
                _name.text = $"@{_viewModel.Name}";
                _description.text = _viewModel.Description;
                _playerIcon.sprite = _viewModel.Icon;
            }
        public void Dispose()
        {
            if (_viewModel != null)
                _viewModel.OnInformationChanged -= UpdateUI;
        }
        }
}
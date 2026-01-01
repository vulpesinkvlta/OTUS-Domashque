using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public class CharacterPopupView : MonoBehaviour
    {
        [SerializeField] private CharacterInformationView _infoView;
        [SerializeField] private CharacterProgressView _progressView;
        [SerializeField] private CharacterStatsView _statsView;

        [SerializeField] private Button _closeButton;
        public void Show(IViewModel viewModel)
        {
            if (viewModel is not ICharacterPopupViewModel characterPopUpViewModel)
            {
                throw new Exception($"Invalid view model type: {viewModel.GetType().Name}");
            }

            _infoView.Bind(characterPopUpViewModel.InfoVM);
            _progressView.Bind(characterPopUpViewModel.ProgressVM);
            _statsView.Bind(characterPopUpViewModel.StatsVM);

            gameObject.SetActive(true);
        }
        private void Awake()
        {
            _closeButton.onClick.AddListener(Hide);
        }

        public void Hide()
        {
            gameObject.SetActive(false);   
        }
    }
}
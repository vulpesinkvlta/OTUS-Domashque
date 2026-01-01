using System;
using TMPro;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public class CharacterProgressView : MonoBehaviour, IDisposable
    {
        [SerializeField] private TMP_Text _level;
        [SerializeField] private TMP_Text _experience;

        [SerializeField] private LevelUpButton _levelUpButton;
        [SerializeField] private ExperienceSlider _xpSlider;

        private ICharacterProgressViewModel _viewModel;
        public void Bind (ICharacterProgressViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.OnProgressChanged += UpdateUI;
            _levelUpButton.AddListener(OnLevelUpButtonClicked);
            UpdateUI();
        }

        private void UpdateUI()
        {
            _level.text = $"Level: {_viewModel.Level}";
            _experience.text = $"XP: {_viewModel.Experience}/{_viewModel.RequiredExp}";

            LevelUp(_viewModel.CanUpgrade);
        }

        private void LevelUp(bool canUpgrade)
        {
            ButtonState buttonState = canUpgrade ? ButtonState.Avilable : ButtonState.Locked;
            SliderState sliderState = canUpgrade ? SliderState.Filled : SliderState.Unfilled;
            _levelUpButton.SetState(buttonState);
            _xpSlider.SetState(sliderState);
            float currentXP = float.Parse(_viewModel.Experience);
            float requiredXP = float.Parse(_viewModel.RequiredExp);
            _xpSlider.Slider.maxValue = requiredXP;
            _xpSlider.Slider.value = currentXP;
        }

        private void OnLevelUpButtonClicked()
        {
            if (_viewModel.CanUpgrade)
            {
                _viewModel.LevelUp();
            }
        }

        public void Dispose()
        {
            _levelUpButton.RemoveListener(OnLevelUpButtonClicked);
            _viewModel.OnProgressChanged -= UpdateUI;
        }
    }
}
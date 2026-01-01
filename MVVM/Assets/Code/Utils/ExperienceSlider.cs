using Lessons.Architecture.PM;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public class ExperienceSlider : MonoBehaviour
    {
        [SerializeField]
        private Sprite _filledImage;
        [SerializeField]
        private Sprite _unfilledImage;
        [SerializeField]
        private Image _sliderImage;
        [SerializeField]
        private SliderState _state;

        [SerializeField]
        private Slider _slider;

        public Slider Slider => _slider;

        private void Start()
        {
            Slider.interactable = false;
        }

        public void SetValue(float current, float max)
        {
            Slider.maxValue = max;
            Slider.value = current;
        }
        internal void SetState(SliderState sliderState)
        {
            _state = sliderState;
            switch (_state)
            {
                case SliderState.Filled:
                    _sliderImage.sprite = _filledImage;
                    break;
                case SliderState.Unfilled:
                    _sliderImage.sprite = _unfilledImage;
                    break;
                default:
                    throw new Exception($"Undefined button state {sliderState}!");

            }
        }
    }
}
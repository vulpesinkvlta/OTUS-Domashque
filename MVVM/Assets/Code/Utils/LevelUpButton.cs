using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class LevelUpButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        Image _buttonBackground;
        [SerializeField]
        private Sprite _availableButtonSprite;
        [SerializeField]
        private Sprite _lockedButtonSprite;

        [SerializeField]
        private ButtonState _state;

        public Button Button => _button;

        public void AddListener(UnityAction action)
        {
            Button.onClick.AddListener(action);
        }

        public void RemoveListener(UnityAction action)
        {
            Button.onClick.RemoveListener(action);
        }

        public void SetAvailable(bool isAvailable)
        {
            var state = isAvailable? ButtonState.Avilable : ButtonState.Locked;
            SetState(state);
        }
        
        internal void SetState(ButtonState buttonState)
        {
            _state = buttonState;
            switch (_state)
            {
                case ButtonState.Avilable:
                    Button.interactable = true;
                    _buttonBackground.sprite = _availableButtonSprite;
                    break;
                case ButtonState.Locked:
                     Button.interactable = false;
                    _buttonBackground.sprite = _lockedButtonSprite;
                    break;  
                default:
                    throw new Exception($"Undefined button state {buttonState}!");

            }
        }
    }
}
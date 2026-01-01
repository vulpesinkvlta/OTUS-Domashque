using TMPro;
using UnityEngine;

namespace Lessons.Architecture.PM
{

    public class StatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private IStatViewModel _viewModel;

        public void Bind(IStatViewModel vm)
        {
            _viewModel = vm;
            _viewModel.OnChanged += UpdateUI;
            UpdateUI();
        }

        private void UpdateUI()
        {
            _text.text = $"{_viewModel.Name}: {_viewModel.Value}";
        }

        private void OnDestroy()
        {
            if (_viewModel != null)
                _viewModel.OnChanged -= UpdateUI;
        }
    }
}

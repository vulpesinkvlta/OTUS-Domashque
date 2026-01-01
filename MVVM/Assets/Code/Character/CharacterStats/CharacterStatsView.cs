using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Lessons.Architecture.PM
{
    public sealed class CharacterStatsView : MonoBehaviour, IDisposable
    {
        [SerializeField] private StatView _statPrefab;
        [SerializeField] private Transform _container;

        private IStatsViewModel _viewModel;
        private readonly List<StatView> _items = new();

        public void Bind(IStatsViewModel vm)
        {
            _viewModel = vm;
            _viewModel.OnStatsValueChanged += Rebuild;
            Rebuild();
        }

        private void Rebuild()
        {
            foreach (var item in _items)
                Destroy(item.gameObject);

            _items.Clear();

            foreach (var statVM in _viewModel.Stats)
            {
                var view = Instantiate(_statPrefab, _container);
                view.Bind(statVM);
                _items.Add(view);
            }
        }

        public void Dispose()
        {
            if (_viewModel != null)
                _viewModel.OnStatsValueChanged -= Rebuild;
        }
    }
}

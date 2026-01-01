
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons.Architecture.PM
{
    public class CharacterStatsViewModel : IStatsViewModel
    {
        public IReadOnlyList<IStatViewModel> Stats => _stats;

        private readonly List<IStatViewModel> _stats = new();
        private readonly CharacterInfo _characterInfo;

        public event Action OnStatsValueChanged;

        public CharacterStatsViewModel(CharacterInfo characterInfo)
        {
            _characterInfo = characterInfo;

            foreach (var stat in characterInfo.GetStats())
                AddStat(stat);

            _characterInfo.OnStatAdded += AddStat;
            _characterInfo.OnStatRemoved += RemoveStat;
        }

        private void AddStat(CharacterStat stat)
        {
            _stats.Add(new StatViewModel(stat));
            OnStatsValueChanged?.Invoke();
        }

        private void RemoveStat(CharacterStat stat)
        {
            var vm = _stats.First(x => x.Name == stat.Name);
            (vm as IDisposable)?.Dispose();
            _stats.Remove(vm);
            OnStatsValueChanged?.Invoke();
        }

        public void Dispose()
        {
            _characterInfo.OnStatAdded -= AddStat;
            _characterInfo.OnStatRemoved -= RemoveStat;

            foreach (var stat in _stats.OfType<IDisposable>())
                stat.Dispose();
        }
    }
}
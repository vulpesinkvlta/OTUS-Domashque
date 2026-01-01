using Lessons.Architecture.PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Architecture.PM
{
    public sealed class StatViewModel : IStatViewModel, IDisposable
    {
        public string Name { get; }
        public int Value { get; private set; }

        public event Action OnChanged;

        private readonly CharacterStat _stat;

        public StatViewModel(CharacterStat stat)
        {
            _stat = stat;
            Name = stat.Name;
            Value = stat.Value;
            _stat.OnValueChanged += OnValueChanged;
        }

        private void OnValueChanged(int value)
        {
            Value = value;
            OnChanged?.Invoke();
        }

        public void Dispose()
        {
            _stat.OnValueChanged -= OnValueChanged;
        }
    }

}

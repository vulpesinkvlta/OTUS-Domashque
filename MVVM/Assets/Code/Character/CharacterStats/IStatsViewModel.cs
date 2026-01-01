
using System;
using System.Collections.Generic;

namespace Lessons.Architecture.PM
{
    public interface IStatsViewModel : IViewModel
    {
        public IReadOnlyList<IStatViewModel> Stats { get; }

        public event Action OnStatsValueChanged;
    }
}
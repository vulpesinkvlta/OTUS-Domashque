using System;

namespace Lessons.Architecture.PM
{
    public interface ICharacterProgressViewModel : IViewModel
    {
        public string Level { get; }
        public string Experience { get; }
        public string RequiredExp { get; }
        bool CanUpgrade { get; }

        public event Action OnProgressChanged;
        void LevelUp();
        void OnExperienceChanged(int exp);
    }
}
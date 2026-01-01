using Lessons.Architecture.PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Character
{
    public class CharacterProgressViewModel : ICharacterProgressViewModel, IDisposable
    {
        public string Level { get; private set; }
        public string Experience { get; private set; }
        public string RequiredExp { get; private set; }
        public bool CanUpgrade { get; private set; }

        public event Action OnProgressChanged;

        private readonly PlayerLevel _level;

        public CharacterProgressViewModel(PlayerLevel playerLevel)
        {
            _level = playerLevel;
            _level.OnLevelUp += LevelUp;
            _level.OnExperienceChanged += OnExperienceChanged;
            UpdateAll();
        }

        private void UpdateAll()
        {
            Level = _level.CurrentLevel.ToString();
            Experience = _level.CurrentExperience.ToString();   
            RequiredExp = _level.RequiredExperience.ToString();
            CanUpgrade = _level.CanLevelUp();
            
            OnProgressChanged?.Invoke();
        }

        public void LevelUp()
        {
            if (CanUpgrade)
            {
                _level.LevelUp();
            }
            UpdateAll();
        }

        public void OnExperienceChanged(int exp)
        {
            Experience = exp.ToString();
            CanUpgrade = _level.CanLevelUp();
            OnProgressChanged?.Invoke();
        }

        public void Dispose()
        {
            _level.OnLevelUp -= LevelUp;
            _level.OnExperienceChanged -= OnExperienceChanged;
        }
    }
}

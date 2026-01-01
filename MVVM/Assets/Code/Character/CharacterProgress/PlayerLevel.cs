using System;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevel
    {
        public event Action OnLevelUp;
        public event Action<int> OnExperienceChanged;

        public int CurrentLevel { get; private set; } = 1;

        public int CurrentExperience { get; private set; }

        public void Initialize(int level, int experience)
        {
            CurrentExperience = experience;
            CurrentLevel = level;   
            OnExperienceChanged?.Invoke(CurrentExperience);
        }
        public int RequiredExperience
        {
            get { return 100 * (this.CurrentLevel + 1); }
        }

        public void AddExperience(int range)
        {
            var xp = Math.Min(this.CurrentExperience + range, this.RequiredExperience);
            this.CurrentExperience = xp;
            this.OnExperienceChanged?.Invoke(xp);
        }

        public void LevelUp()
        {
            if (this.CanLevelUp())
            {
                this.CurrentExperience = 0;
                this.CurrentLevel++;
                OnExperienceChanged?.Invoke(CurrentExperience);
                this.OnLevelUp?.Invoke();
            }
        }

        public bool CanLevelUp()
        {
            return this.CurrentExperience == this.RequiredExperience;
        }
    }
}
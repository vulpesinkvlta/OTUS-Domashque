using Assets.Code.Character;

namespace Lessons.Architecture.PM
{
    public interface ICharacterPopupViewModel : IViewModel
    {
        public ICharacterInformationViewModel InfoVM { get; }
        public ICharacterProgressViewModel ProgressVM { get; }
        public IStatsViewModel StatsVM { get; }
    }
}
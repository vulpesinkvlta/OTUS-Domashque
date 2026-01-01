using Lessons.Architecture.PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Character
{
    public class CharacterPopupViewModel : ICharacterPopupViewModel
    {
        public ICharacterInformationViewModel InfoVM { get; private set; }
        public ICharacterProgressViewModel ProgressVM { get; private set; }
        public IStatsViewModel StatsVM { get; private set; }

        public CharacterPopupViewModel(
            CharacterInformationViewModel infoViewModel,
            CharacterProgressViewModel progressViewModel,
            CharacterStatsViewModel statsViewModel)                            
        {
            InfoVM = infoViewModel;
            ProgressVM = progressViewModel;
            StatsVM = statsViewModel;
        }
    }
}
using Assets.Code.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterPopupViewModelFactory
    {
        public CharacterPopupViewModel Create(PlayerFacade context)
        {
            var infoVM = new CharacterInformationViewModel(context.UserInfo);
            var progressVM = new CharacterProgressViewModel(context.Level);
            var statsVM = new CharacterStatsViewModel(context.Stats);

            return new CharacterPopupViewModel(infoVM, progressVM, statsVM);
        }
    }
}

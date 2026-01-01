using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Zenject.SpaceFighter;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerFactory
    {
        public PlayerFacade Create(PlayerDataConfig config)
        {
            var userInfo = new UserInfo();
            userInfo.ChangeName(config.Name);
            userInfo.ChangeDescription(config.Description);
            userInfo.ChangeIcon(config.Icon);

            var level = new PlayerLevel();
            level.Initialize(config.StartLevel, config.StartExperience);

            var characterInfo = new CharacterInfo();
            foreach (var stat in config.Stats)
            {
                characterInfo.AddStat(
                    new CharacterStat(stat.Name, stat.BaseValue)
                );
            }

            return new PlayerFacade(userInfo, level, characterInfo);
        }
    }
}

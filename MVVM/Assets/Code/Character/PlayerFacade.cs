namespace Lessons.Architecture.PM
{
    public sealed class PlayerFacade
    {
        public UserInfo UserInfo { get; }
        public PlayerLevel Level { get; }
        public CharacterInfo Stats { get; }

        public PlayerFacade(UserInfo userInfo, PlayerLevel level, CharacterInfo stats)
        {
            UserInfo = userInfo;
            Level = level;
            Stats = stats;
        }
    }
}
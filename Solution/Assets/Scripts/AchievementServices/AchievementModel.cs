using AchievementSO;

namespace AchievementServices
{
    public class AchievementModel
    {
        public BulletsFiredAchievementSO BulletsFiredAchievement { get; private set; }
        public EnemiesKilledAchievementSO EnemiesKilledAchievement { get; private set; }


        public AchievementModel(AchievementHolder achievements)
        {
            BulletsFiredAchievement = achievements.BulletFiredAchievementSO;
            EnemiesKilledAchievement = achievements.EnemiesKilledAchievementSO;

        }
    }
}
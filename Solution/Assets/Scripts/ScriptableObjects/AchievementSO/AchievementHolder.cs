using UnityEngine;

namespace AchievementSO
{
    [CreateAssetMenu(fileName = "AchievementHolder", menuName = "ScriptableObject/Achievement/NewAchievementListSO")]
    public class AchievementHolder : ScriptableObject
    {
        public BulletsFiredAchievementSO BulletFiredAchievementSO;
        public EnemiesKilledAchievementSO EnemiesKilledAchievementSO;
    }
}
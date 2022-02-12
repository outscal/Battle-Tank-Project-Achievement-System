using System;
using UnityEngine;

namespace AchievementSO
{
    [CreateAssetMenu(fileName = "BulletsFiredAchievementSO", menuName = "ScriptableObject/Achievement/NewBulletsFiredAchievementSO")]
    public class BulletsFiredAchievementSO : ScriptableObject
    {
        public Tier[] Tiers;

        [Serializable]
        public class Tier
        {
            public enum BulletAchievements
            {
                None,
                Gunner,
                SubMachineGunner,
                HeavyMachineGunner,
                ShellThrower,
            }
            public string name;
            public string info;
            public BulletAchievements SelectAchievement;
            public int requirement;
        }
    }
}
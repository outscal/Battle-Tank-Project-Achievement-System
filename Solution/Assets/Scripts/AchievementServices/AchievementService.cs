using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using AchievementSO;
namespace AchievementServices
{
    public class AchievementService : GenericMonoSingleton<AchievementService>
    {
        public AchievementHolder allAchievements;
        private AchievementController achievementController;
        private void Start()
        {
            CreateAchievementMVC();
        }
        private void CreateAchievementMVC()
        {
            AchievementModel model = new AchievementModel(allAchievements);
            AchievementController controller = new AchievementController(model);
            achievementController = controller;
        }
        public AchievementController GetAchievementController()
        {
            return achievementController;
        }
    }
}
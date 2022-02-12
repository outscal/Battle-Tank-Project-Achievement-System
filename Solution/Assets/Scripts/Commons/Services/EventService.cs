
using System;

namespace Commons
{
    public class EventService : GenericMonoSingleton<EventService>
    {
        public event Action OnEnemyDeath;
        public event Action OnPlayerFiredBullet;


        public void InvokeOnPlayerFiredBulletEvent()
        {
            OnPlayerFiredBullet?.Invoke();
        }
        public void InvokeEnemyKilledEvent()
        {
            OnEnemyDeath?.Invoke();
        }

    }
}
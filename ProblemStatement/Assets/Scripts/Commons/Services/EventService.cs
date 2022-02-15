
using System;

namespace Commons
{
    public class EventService : GenericMonoSingleton<EventService>
    {
        public event Action OnEnemyDeath;
        public event Action OnPlayerFiredBullet;


        //  private void Start()
        //  {
        //      OnPlayerFiredBullet?.Invoke();
        //  }
        public void InvokeEvent()
        {
            OnPlayerFiredBullet?.Invoke();
        }

    }
}
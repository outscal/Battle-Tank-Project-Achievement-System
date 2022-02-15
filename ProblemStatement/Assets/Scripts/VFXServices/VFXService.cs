
using UnityEngine;
using Commons;


namespace VFXServices
{
    public class VFXService : GenericMonoSingleton<VFXService>
    {
        public void InstantiateEffects(GameObject Effects, Vector3 position)
        {
            GameObject gameObject = Instantiate(Effects, position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }
    }
}


using UnityEngine;

namespace BulletSO
{
    public class BulletSOList : ScriptableObject
    {
        [CreateAssetMenu(fileName = "BulletSOList", menuName = "ScriptableObject/Bullet/NewBulletScriptableObjectList")]
        public class BulletScriptableObjectList : ScriptableObject
        {
            public BulletScriptableObject[] bulletsTypes;
        }
    }
}
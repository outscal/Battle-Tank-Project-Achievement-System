
using UnityEngine;
namespace EnemySO
{
    [CreateAssetMenu(fileName = "EnemySOList", menuName = "ScriptableObject/Enemy/NewEnemykScriptableObjectList")]
    public class EnemySOList : ScriptableObject
    {
        public EnemyScriptableObject[] enemies;

        //add here some comman things which are every enemies....
    }
}
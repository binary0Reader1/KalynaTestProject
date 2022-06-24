using FactoryObjects.Enemies;
using UnityEngine;

namespace Level
{
    public abstract class LevelConfig : MonoBehaviour
    {
        public abstract EnemyType[] LevelEnemies { get; protected set; }
    }
}
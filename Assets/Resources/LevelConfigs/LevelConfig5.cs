using FactoryObjects.Enemies;
using Level;

public class LevelConfig5 : LevelConfig
{
    public override EnemyType[] LevelEnemies { get; protected set; } = new EnemyType[]
    {
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy,
        EnemyType.BigEnemy
    };
}

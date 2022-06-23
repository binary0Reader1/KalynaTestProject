using FactoryObjects.Enemies;
using Level;

public class LevelConfig6 : LevelConfig
{
    public override EnemyType[] LevelEnemies { get; protected set; } = new EnemyType[]
    {
        EnemyType.BigEnemy,
        EnemyType.FastEnemy
    };
}

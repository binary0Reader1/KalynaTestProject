using FactoryObjects.Enemies;
using Level;

public class LevelConfig2 : LevelConfig
{
    public override EnemyType[] LevelEnemies { get; protected set; } = new EnemyType[]
    {
        EnemyType.DefaultEnemy,
        EnemyType.DefaultEnemy,
    };
}

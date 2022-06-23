using FactoryObjects.Enemies;
using Level;

public class LevelConfig1 : LevelConfig
{
    public override EnemyType[] LevelEnemies { get; protected set; } = new EnemyType[]
    {
        EnemyType.DefaultEnemy
    };
}
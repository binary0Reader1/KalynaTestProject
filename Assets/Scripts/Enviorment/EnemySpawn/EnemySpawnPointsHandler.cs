using Level;
using Level.Objects;
using Sugar;
using System;

namespace Enviorment.EnemySpawn
{
    public class EnemySpawnPointsHandler : RequiredLevelObject
    {
        public override int InitializeOrder { get; protected set; } = 500;
        public EnemySpawnPoint[] SpawnPoints { get; private set; }

        protected override void InitializeInstruction(LevelManagement levelManagement)
        {
            SpawnPoints = GetComponentsInChildren<EnemySpawnPoint>();

            if (SpawnPoints.Length == 0) throw new Exception(GetType().Name + " " + StringConstants.ObjectIsNotInitializedExcpetionTitle);
        }

        protected override void OnLevelEndedInstuction()
        {

        }
    }
}
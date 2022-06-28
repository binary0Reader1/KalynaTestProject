using Enemies;

namespace ObjectSettings.Enemies.States
{
    public abstract class EnemyState
    {
        protected readonly Enemy _attachedEnemy;
        protected readonly IEnemyStateSwitcher _attachedEnemyStateSwitcher;

        public EnemyState(Enemy attachedEnemy, IEnemyStateSwitcher attachedEnemyStateSwitcher)
        {
            _attachedEnemy = attachedEnemy;
            _attachedEnemyStateSwitcher = attachedEnemyStateSwitcher;
        }

        public abstract void StartAction();
        public abstract void UpdateAction();
        public abstract void FixedUpdateAction();
        public abstract void ExitAction();
    }
}
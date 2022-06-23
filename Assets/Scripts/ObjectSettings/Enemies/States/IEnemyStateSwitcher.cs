namespace ObjectSettings.Enemies.States
{
    public interface IEnemyStateSwitcher
    {
        public void SwitchState<T>() where T : EnemyState;
    }
}
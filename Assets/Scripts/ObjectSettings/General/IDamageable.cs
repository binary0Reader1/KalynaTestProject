namespace ObjectSettings.General
{
    public interface IDamageable
    {
        public float Damage { get; set; }
        public void DoDamage();
    }
}
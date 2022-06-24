using System;

namespace ObjectSettings.General
{
    public interface IHealthChangeable : IHealth
    {
        public Action OnHealthChanged { get; set; }
        public void ChangeHealth(float value);
    }
}
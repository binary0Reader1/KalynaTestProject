using Level;
using Level.Objects;
using ObjectSettings.General;
using UnityEngine;

namespace Enviorment
{
    public class DeathTrigger : RequiredLevelObject
    {
        public override int InitializeOrder { get; protected set; } = 0;

        protected override void InitializeInstruction(LevelManagement levelManagement)
        {

        }

        protected override void OnLevelEndedInstuction()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IHealthChangeable healthChangeableObject))
            {
                Debug.Log("killed " + other.name);
                healthChangeableObject.ChangeHealth(-healthChangeableObject.MaxHealth);
            }
        }
    }
}
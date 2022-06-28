using ObjectSettings.General;
using UnityEngine;

namespace Enviorment
{
    public class DeathTrigger : MonoBehaviour
    { 
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
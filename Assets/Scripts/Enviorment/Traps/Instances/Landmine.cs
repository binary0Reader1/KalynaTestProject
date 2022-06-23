using ObjectSettings.General;
using UnityEngine;

namespace Enviorment.Traps.Instances
{
    public class Landmine : TrapObject
    {
        [SerializeField] private float _damage = 50;
        [SerializeField] private float _explosionRadius = 3;
        [SerializeField] private float _explosionForce = 1000;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("enterd");
            if (other.TryGetComponent(out Rigidbody rigidbodyObject))
            {
                Debug.Log("enteredTwice");
                Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].TryGetComponent(out Rigidbody nearbyObjectRigidbody))
                    {
                        Debug.Log("enteredTriple");
                        nearbyObjectRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
                    }

                    if (colliders[i].TryGetComponent(out IHealthChangeable nearbyHealthChangeableObject))
                    {
                        Debug.Log("enteredFourtly");
                        float damage = _damage / Vector3.Distance(transform.position, other.transform.position);
                        nearbyHealthChangeableObject.ChangeHealth(-damage);
                    }
                }
            }

            Destroy(gameObject);
        }
    }
}
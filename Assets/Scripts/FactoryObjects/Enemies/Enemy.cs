using ObjectSettings.Enemies.States;
using ObjectSettings.General;
using Sugar;
using System;
using UnityEngine;

namespace FactoryObjects.Enemies
{
    public abstract class Enemy : FactoryObject, IEnemyStateSwitcher, IHealthChangeable, IDestructable
    {
        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float Health { get; set; }
        public Action OnHealthChanged { get; set; }
        public Action<Collision> OnCollision { get; set; }
        public Action OnDestruct { get; set; }
        public Rigidbody RigidbodyReference { get; private set; }
        public EnemyState[] States { get; private set; }

        [SerializeField] private float _maxHealth = 100;

        private EnemyState _currentState;

        private void Start()
        {
            RigidbodyReference = GetComponent<Rigidbody>();
            States = InitializeStatesInstruction();

            if (MaxHealth <= 0) throw new Exception(GetType().Name + " " + StringConstants.ObjectIsNotInitializedExcpetionTitle);

            Health = MaxHealth;

            if (States.Length == 0) throw new Exception(GetType().Name + " " + StringConstants.ObjectIsNotInitializedExcpetionTitle);

            _currentState = States[0];
            _currentState.StartAction();
        }
        private void Update()
        {
            _currentState?.UpdateAction();
        }
        private void OnCollisionEnter(Collision collision)
        {
            OnCollision?.Invoke(collision);
        }

        public void ChangeHealth(float value)
        {
            Health = Mathf.Clamp(Health + value, 0, MaxHealth);

            OnHealthChanged?.Invoke();

            if (Health == 0) Destruct();
        }
        public void Destruct()
        {
            OnDestruct?.Invoke();

            RigidbodyReference.freezeRotation = false;
            _currentState?.ExitAction();
            _currentState = null;
        }
        public void SwitchState<T>() where T : EnemyState
        {
            _currentState?.ExitAction();

            for (int i = 0; i < States.Length; i++)
            {
                if (States[i] is T)
                {
                    _currentState = States[i];
                    break;
                }
            }

            _currentState.StartAction();
        }

        /// <summary>
        /// Here goes your states declaration
        /// </summary>
        /// <returns></returns>
        protected abstract EnemyState[] InitializeStatesInstruction();
    }

    public class EnemyType : FactoryObjectType
    {


        protected EnemyType(string key) : base(key)
        {

        }

        public static readonly EnemyType DefaultEnemy = new(StringConstants.DefaultEnemyID);
        public static readonly EnemyType FastEnemy = new(StringConstants.FastEnemyID);
        public static readonly EnemyType BigEnemy = new(StringConstants.BigEnemyID);
    }
}
    using UnityEngine;

using ChickenDayZ.Gameplay.Health;

namespace ChickenDayZ.Gameplay.Characters.Zombie
{   
    public class ZombieAttacking : MonoBehaviour
    {
        [SerializeField] private float _zombieInitialDamage;

        [SerializeField] private float _zombieAttackCooldownTime;

        private ZombieTarget _zombieTarget;

        private ObjectHealth _targetHealth;

        private float _zombieDamage;

        private float _attackCooldownTimer;

        private bool _inAttackMode;

        void Awake()
        {
            _zombieTarget = gameObject.GetComponent<ZombieTarget>();
        }

        void OnEnable()
        {
            _zombieTarget.OnTargetChanged += UpdateTargetHealth;
        }

        void OnDisable()
        {
            _zombieTarget.OnTargetChanged -= UpdateTargetHealth;
        }

        void Start()
        {
            _zombieDamage = _zombieInitialDamage;

            _attackCooldownTimer = 0f;

            _inAttackMode = false;
        }

        void Update()
        {
            EnterAttackModeIfZombieIsInTarget();

            AttackTargetIfIsInAttackMode();

            DecreaseCooldownTimerIfZombieHasAttacked();
        }

        private void EnterAttackModeIfZombieIsInTarget()
        {
            if (_zombieTarget.IsZombieCollidingWithTarget && _attackCooldownTimer <= 0f)
            {
                _inAttackMode = true;
            }
        }

        private void AttackTargetIfIsInAttackMode()
        {
            if (_inAttackMode)
            {
                _targetHealth.ReceiveDamage(_zombieDamage);

                _attackCooldownTimer = _zombieAttackCooldownTime;

                _inAttackMode = false;
            }
        }

        private void DecreaseCooldownTimerIfZombieHasAttacked()
        {
            if (_attackCooldownTimer > 0f)
            {
                _attackCooldownTimer -= Time.deltaTime;

                if (_attackCooldownTimer < 0f)
                {
                    _attackCooldownTimer = 0f;
                }
            }
        }        

        private void UpdateTargetHealth() 
        {            
            _targetHealth = _zombieTarget.Target.GetComponent<ObjectHealth>();

            _attackCooldownTimer = 0f;
        }
    }
}

using UnityEngine;
using RPG.Movement;
using RPG.Core;
using RPG.Combat;
namespace RPG.Combat 
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2.0f;
        [SerializeField] float playerAttackPoints = 10.0f;
        [SerializeField] float weaponAttackPoints = 10.0f;
        [SerializeField] float timeBetweenAttacks = 1.0f;

        private Transform _target;
        private Traversal _traversal;
        private float _timeSinceLastAttack = 0;



        private void Start()
        {
        }
        
        private void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;
            if(_target == null) return;
            if(!_IsInWeaponRange())
            {
                _MoveToTarget();
            }
            else
            {
                
                _AttackBehaviour();
            }
        }

        private void _AttackBehaviour()
        {
                // Stop when in weapon range and start attack animation
                if(_timeSinceLastAttack < timeBetweenAttacks) return;
                _timeSinceLastAttack = 0;

                // Cancel attack if target health is 0 or less
                if(_getTargetHealthComponent().GetCurrentHealth() <= 0)
                {
                    Cancel();
                    return;
                }

                GetComponent<Animator>().SetTrigger(Triggers.attack);
                // The damage reduction will happen in the Hit() during the animation
        }
        
        public void Attack(Transform target)
        {
            this._target = target;
            GetComponent<ActionScheduler>().StartAction(this);
            
        }

        
        // Hit is an animation event triggered when the animation is hitting another object
        void Hit()
        {
            // Deal damage otherwise
            _getTargetHealthComponent().TakeDamage(_GetAttackPoints());
        }

        public bool IsFighting()
        {
            return _target != null;
        }

        public void Cancel()
        {
            this._target = null;
            // GetComponent<Animator>().SetTrigger(Triggers.stopAttack);
        }


        private void _MoveToTarget()
        {
            // TODO: Check why this is getting null reference
            // traversal.MoveTo(target.position);
            _GetTraversal().moveTo(_target.position);

            // to prevent repeated calls to traversal stop 
            // putting the mesh agent stop here
            if(_IsInWeaponRange())
            {
                _GetTraversal().stop();
            }
        }

        private bool _IsInWeaponRange()
        {
            return Vector3.Distance(_target.position, transform.position) <= weaponRange;
        }

        private Traversal _GetTraversal()
        {
            return GetComponent<Traversal>();
        }

        private CombatTarget _GetCombatTarget()
        {
            return GetComponent<CombatTarget>();
        }

        private float _GetAttackPoints()
        {
            return (float)(playerAttackPoints * 0.8 + weaponAttackPoints * 1.2);
        }

        private Health _getTargetHealthComponent()
        {
            return _target.GetComponent<Health>();
        }
        
    }
}
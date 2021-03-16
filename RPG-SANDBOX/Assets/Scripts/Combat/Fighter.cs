using UnityEngine;
using RPG.Movement;
using RPG.Core;
namespace RPG.Combat 
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2.0f;
        Transform target;
        Traversal traversal;

        private void Start()
        {
        }
        
        private void Update()
        {
            if(target == null) return;
            if(!_IsInWeaponRange())
            {
                _MoveToTarget();
            }
            else
            {
                _GetTraversal().Stop();
            }
        }
        
        public void Attack(Transform target)
        {
            this.target = target;
            GetComponent<ActionScheduler>().StartAction(this);
        }

        public bool IsFighting()
        {
            return target != null;
        }

        public void Cancel()
        {
            this.target = null;
        }

        private void _MoveToTarget()
        {
            // TODO: Check why this is getting null reference
            // traversal.MoveTo(target.position);
            _GetTraversal().MoveTo(target.position);
        }

        private bool _IsInWeaponRange()
        {
            return Vector3.Distance(target.position, transform.position) <= weaponRange;
        }

        private Traversal _GetTraversal()
        {
            return GetComponent<Traversal>();
        }
        
    }
}
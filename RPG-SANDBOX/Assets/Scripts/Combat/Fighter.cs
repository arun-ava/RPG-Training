using UnityEngine;
using RPG.Movement;
using RPG.Core;
namespace RPG.Combat 
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2.0f;
        Transform target;
        Mover mover;

        private void Start()
        {
            mover = GetComponent<Mover>();
        }
        private void Update()
        {
            if(target == null) return;
            if(!IsInWeaponRange())
            {
                MoveToTarget();
            }
            else
            {
                GetComponent<Mover>().Stop();
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

        private void MoveToTarget()
        {
            mover.MoveTo(target.position);
        }

        private bool IsInWeaponRange()
        {
            return Vector3.Distance(target.position, transform.position) <= weaponRange;
        }
        
    }
}
using UnityEngine;
using RPG.Movement;

namespace RPG.Combat 
{
    public class Fighter : MonoBehaviour
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
            MoveToTarget();
        }
        
        public void Attack(Transform target)
        {
            this.target = target;
        }

        public void Stop()
        {
            // Debug.Log("Stopped");
            this.target = null;
            this.mover.Stop();
        }

        private void MoveToTarget()
        {
            if(target == null) return;
            
            bool isInWeaponRange = Vector3.Distance(target.position, transform.position) < weaponRange;
            
            if(target != null && !isInWeaponRange)
            {
                mover.MoveTo(target.position);
            } else 
            {
                mover.Stop();
            }
        }
        
    }
}
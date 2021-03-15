using UnityEngine;
using UnityEngine.AI;
using RPG.Core;
namespace RPG.Movement 
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;
        private NavMeshAgent Agent;
        
        // Start is called before the first frame update
        private void Start()
        {
            Agent = GetComponent<NavMeshAgent>();
            Agent.isStopped = false;
        }

        public void Stop()
        {
            Agent.isStopped = true;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateAnimator();
        }

        public bool StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            return MoveTo(destination);
        }

        public void Cancel()
        {}

        public bool MoveTo(Vector3 destination)
        {
            NavMeshPath travelPath = new NavMeshPath();
            bool hasPath = Agent.CalculatePath(destination, travelPath);
            if(hasPath)
            {
                Agent.SetPath(travelPath);
                Agent.isStopped = false;
                return true;
            }
            return false;
        }

        private void UpdateAnimator()
        {
            Vector3 globalVelocity = Agent.velocity;
            Vector3 localVelocity = transform.InverseTransformVector(globalVelocity);
            float speed = localVelocity.z;
            Animator an = GetComponent<Animator>();
            an.SetFloat("Blend", speed);
        }
    }
}
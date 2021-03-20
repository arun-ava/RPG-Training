using UnityEngine;
using UnityEngine.AI;

namespace RPG.Core 
{
    public class Traversal : MonoBehaviour
    {
        private NavMeshAgent Agent;
        private const string TRAVERSAL_BLEND_FIELD = "forwardSpeed";
            
        // Start is called before the first frame update
        private void Start()
        {
            Agent = GetComponent<NavMeshAgent>();
            Agent.isStopped = false;
            Debug.Log("travesal start");
        }

        // Update is called once per frame
        private void Update()
        {
            _updateAnimator();
        }

        public void stop()
        {
            Agent.isStopped = true;
            Debug.Log("travesal stop");
        }

        public bool moveTo(Vector3 destination)
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

        private void _updateAnimator()
        {
            Vector3 globalVelocity = Agent.velocity;
            Vector3 localVelocity = transform.InverseTransformVector(globalVelocity);
            float speed = localVelocity.z;
            Animator an = GetComponent<Animator>();
            an.SetFloat(TRAVERSAL_BLEND_FIELD, speed);
        }
    }
}
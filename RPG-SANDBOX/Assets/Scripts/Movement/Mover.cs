using UnityEngine;
using RPG.Core;
namespace RPG.Movement 
{
    public class Mover : MonoBehaviour, IAction
    {
        // Traversal traversal;

        private void Start()
        {
            // TODO: Check why this is getting null reference. Read order in which objects are initialized
            // traversal = GetComponent<Traversal>();
        }
        
        public bool StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            return _GetTraversal().moveTo(destination);
        }

        public void Cancel()
        {
            _GetTraversal().stop();
        }

        private Traversal _GetTraversal()
        {
            return GetComponent<Traversal>();
        }
    }
}
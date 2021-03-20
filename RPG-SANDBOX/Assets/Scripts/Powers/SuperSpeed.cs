using UnityEngine;
using UnityEngine.AI;

namespace RPG.Powers
{
    public class SuperSpeed : MonoBehaviour
    {
        [SerializeField] float superSpeed = 50.0f;
        private float _originalSpeed = 0f;

        private void Start()
        {
            _originalSpeed = GetComponent<NavMeshAgent>().speed;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<NavMeshAgent>().speed = superSpeed;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                GetComponent<NavMeshAgent>().speed = _originalSpeed;
            }
        }
        
    }
}

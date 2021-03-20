using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

namespace RPG.Movement
{
    public class KeyMover : MonoBehaviour 
    {
        [SerializeField] float stepDistance = 2f;
        [SerializeField] float speed = 50f;
        private NavMeshAgent _navMeshAgent;
        private float _XDisplacement = 0f;
        private float _ZDisplacement = 0f;
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Update()
        {
            _XDisplacement = 0f;
            _ZDisplacement = 0f;

            if(Input.GetKey(KeyCode.W))
            {
                _ZDisplacement += this.stepDistance; // getDistance();
            }
            if(Input.GetKey(KeyCode.A))
            {
                _XDisplacement -= this.stepDistance; // getDistance();
            }
            if(Input.GetKey(KeyCode.S))
            {
                _ZDisplacement -= this.stepDistance;
            }
            if(Input.GetKey(KeyCode.D))
            {
                _XDisplacement += this.stepDistance;
            }

            if(_XDisplacement != 0 || _ZDisplacement != 0)
            {
                Traverse();
            }
        }

        private void RotateAndMove()
        {
            
        }
        private void Traverse()
        {
            GetComponent<NavMeshAgent>().SetDestination(
                new Vector3(_XDisplacement + transform.position.x, 
                0f, 
                _ZDisplacement + transform.position.z)
            );
        }
    }
}
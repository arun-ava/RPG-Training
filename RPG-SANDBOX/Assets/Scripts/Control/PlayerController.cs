using System;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if(InteractWithCombat())
            { 
                return;
            }
            if(InteractWithMovement())
            {
                return;
            }
        }

        private Boolean InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if(target == null) continue;

                if(Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target.transform);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement()
        {
            bool canMoveTo = false;
            if(Input.GetMouseButton(0))
            {
                // // Cancel if attacking someone
                // if(GetComponent<Fighter>().IsFighting())
                // {
                //     GetComponent<Fighter>().Cancel();
                // }
                canMoveTo = MoveToCursor();
            }
            return canMoveTo;
        }

        private bool MoveToCursor()
        {
            bool canMoveTo = false;
            RaycastHit rayInfo;
            bool hasHit = Physics.Raycast(GetMouseRay(), out rayInfo);

            if (hasHit)
            {
                canMoveTo = GetComponent<Mover>().StartMoveAction(rayInfo.point);
            }
            return canMoveTo;

        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
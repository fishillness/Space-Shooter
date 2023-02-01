using UnityEngine;

namespace SpaceShooter
{
    public class Trash : MonoBehaviour
    {
        [SerializeField] private Trigger trigger;
        [SerializeField] private SpaceShip spaceShip;


        private bool trashHold;
        private bool isNear;


        private void Start()
        {
            trigger.Enter.AddListener(OnEnter);
            trigger.Exit.AddListener(OnExit);
            trashHold = false;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q) && isNear == true)
            {
                if (trashHold == false)
                    trashHold = true;
                else
                    trashHold = false;
            }

            if (trashHold == true)
            {
                gameObject.transform.position = spaceShip.transform.GetChild(2).position;
            }   
        }

        private void OnEnter()
        {
            isNear = true;
            
        }
        private void OnExit()
        {
            isNear = false;
        }

    }

}

using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class Gates : MonoBehaviour
    {
        [SerializeField] private UnityEvent m_EventOnWin;
        public UnityEvent EventOnWin => m_EventOnWin;

        [SerializeField] private SpaceShip ship;

        [SerializeField] private int maxNumberTrash;
        private int numberTrash;
        private bool isWin;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var trash = collision.transform.GetComponent<Trash>();

            if (trash != null)
            {
                numberTrash++;
            }

            if (numberTrash == maxNumberTrash && isWin == false)
            {
                m_EventOnWin?.Invoke();
                isWin = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            var trash = collision.transform.GetComponent<Trash>();

            if (trash != null)
            {
                numberTrash--;
            }
        }

    }

}


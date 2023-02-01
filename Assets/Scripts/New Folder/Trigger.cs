using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    public class Trigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent m_enter;
        public UnityEvent Enter => m_enter;
        [SerializeField] private UnityEvent m_exit;
        public UnityEvent Exit => m_exit;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var spaceShip = collision.transform.GetComponent<SpaceShip>();

            if (spaceShip != null)
            {
                Enter?.Invoke();
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            var spaceShip = collision.transform.GetComponent<SpaceShip>();

            if (spaceShip != null)
            {
                Exit?.Invoke();
            }
        }
    }

}

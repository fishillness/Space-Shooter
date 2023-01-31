using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{

    public class CollisionWinZone : MonoBehaviour
    {
        [SerializeField] private UnityEvent m_EventOnWin;
        public UnityEvent EventOnWin => m_EventOnWin;

        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.GetComponent<Destructible>() != null)
            {
                m_EventOnWin?.Invoke();
                Destroy(collision.gameObject);
            }
        }
    }
}


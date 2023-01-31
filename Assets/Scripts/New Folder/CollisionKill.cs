using UnityEngine;

namespace SpaceShooter
{
    public class CollisionKill : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var destructible = collision.transform.GetComponent<Destructible>();

            if (destructible != null)
            {
                destructible.ApplyDamage(destructible.HitPoints);
            }
        }
    }
}


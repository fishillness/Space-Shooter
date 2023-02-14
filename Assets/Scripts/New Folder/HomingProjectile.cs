using UnityEngine;

namespace SpaceShooter
{

    public class HomingProjectile : Projectile
    {
        [SerializeField] private float step;
        private Vector3 targetPosition;
        private bool isEnemyNear;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var obj = collision.transform.root.GetComponent<Destructible>();

            if (obj != null && obj != m_Parent)
            {
                targetPosition = obj.transform.position;
                isEnemyNear = true;
            }
        }

        private void Update()
        {
            if (isEnemyNear == true)
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, step * Time.deltaTime);
        }
    }
}

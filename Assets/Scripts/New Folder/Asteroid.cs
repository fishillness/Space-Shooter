using UnityEngine;

namespace SpaceShooter
{
    public class Asteroid : Destructible
    {
        [SerializeField] private Destructible m_SmallAsteroidPrefab;
        [SerializeField] private float m_SpeedSmallAsteroid;

        private void Awake()
        {
            gameObject.GetComponent<Destructible>().EventOnDeath.AddListener(OnAsteroidDead);

        }

        private void OnAsteroidDead()
        {
            GameObject ast = Instantiate(m_SmallAsteroidPrefab.gameObject);
            ast.transform.position = new Vector3 (deathPosition.x - 1f, deathPosition.y, deathPosition.z);

            Rigidbody2D rb = ast.GetComponent<Rigidbody2D>();
            if (rb != null && m_SpeedSmallAsteroid > 0)
            {
                rb.velocity = (Vector2)UnityEngine.Random.insideUnitSphere * m_SpeedSmallAsteroid;
            }

            GameObject ast2 = Instantiate(m_SmallAsteroidPrefab.gameObject);
            ast.transform.position = new Vector3(deathPosition.x + 1f, deathPosition.y, deathPosition.z);

            Rigidbody2D rb2 = ast.GetComponent<Rigidbody2D>();
            if (rb != null && m_SpeedSmallAsteroid > 0)
            {
                rb.velocity = (Vector2)UnityEngine.Random.insideUnitSphere * m_SpeedSmallAsteroid;
            }
        }
    }
}



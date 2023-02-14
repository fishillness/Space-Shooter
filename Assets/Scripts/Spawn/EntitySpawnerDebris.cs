using UnityEngine;

namespace SpaceShooter
{

    public class EntitySpawnerDebris : MonoBehaviour
    {
        #region Properties
        /// <summary>
        /// An array of all prefabs that can be spawned.
        /// Массив всех префабов, которые возможно заспавнить.
        /// </summary>
        [SerializeField] private Destructible[] m_DebrisPrefabs;
        /// <summary>
        /// Area to spawn into.
        /// Зона, в котороый можно спавнить.
        /// </summary>
        [SerializeField] private CircleArea m_Area;
        /// <summary>
        /// The amount of garbage.
        /// Количество мусора.
        /// </summary>
        [SerializeField] private int m_NumDebris;
        /// <summary>
        /// Speed of garbage movement.
        /// Скорость движения мусора.
        /// </summary>
        [SerializeField] private float m_RandomSpeed;
        #endregion

        #region Unity Events
        private void Start()
        {
            for (int i = 0; i < m_NumDebris; i++)
            {
                SpawnDebris();
            }
        }

        private void SpawnDebris()
        {
            int index = Random.Range(0, m_DebrisPrefabs.Length);

            GameObject debris = Instantiate(m_DebrisPrefabs[index].gameObject);
            debris.transform.position = m_Area.GetRandomInsideZone();
            debris.GetComponent<Destructible>().EventOnDeath.AddListener(OnDebrisDead);

            Rigidbody2D rb = debris.GetComponent<Rigidbody2D>();
            if (rb != null && m_RandomSpeed > 0)
            {
                rb.velocity = (Vector2) UnityEngine.Random.insideUnitSphere * m_RandomSpeed;
            }
        }

        private void OnDebrisDead()
        {
            SpawnDebris();
        }
        #endregion
    }
}

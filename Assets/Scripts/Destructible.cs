using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    /// <summary>
    /// Destructible object on the stage. Something that can have hit points.
    /// ������������ ������ �� �����. �� ��� ����� ����� ���������.
    /// </summary>
    public class Destructible : Entity
    {
        #region Properties
        /// <summary>
        /// The object ignores damage.
        /// ������ ���������� �����������.
        /// </summary>
        [SerializeField] private bool m_Indestructible;
        public bool IsIndestructible => m_Indestructible;

        /// <summary>
        /// Starting number of hitpoints.
        /// ��������� ���-�� ����������.
        /// </summary>
        [SerializeField] private int m_HitPoints;

        /// <summary>
        /// Current hitpoints.
        /// ������� ���������.
        /// </summary>
        private int m_CurrentHitPoints;
        public int HitPoints => m_CurrentHitPoints;

        /// <summary>
        /// Link to the explosion prefab.
        /// ������ �� ������ ������.
        /// </summary>
        [SerializeField] private GameObject m_ExplosionPrefab;


        [SerializeField] private UnityEvent m_EventOnDeath;
        public UnityEvent EventOnDeath => m_EventOnDeath;        
        #endregion

        #region Unity Events
        protected virtual void Start()
        {
            m_CurrentHitPoints = m_HitPoints;
        }

        #endregion

        #region Public API
        /// <summary>
        /// Applying damage to an object.
        /// ���������� ����� � �������.
        /// </summary>
        /// <param name="damage"> Damage dealt to an object. ���� ��������� �������.</param>
        public void ApplyDamage(int damage)
        {
            if (m_Indestructible) return;

            m_CurrentHitPoints -= damage;

            if (m_CurrentHitPoints <= 0)
                OnDeath();
        }

        #endregion

        /// <summary>
        /// Redefinable object destruction event when hitpoints are below or equal to zero.
        /// ���������������� ������� ����������� �������, ����� ��������� ���� ��� ����� ����.
        /// </summary>
        protected virtual void OnDeath()
        {
            var explosion = Instantiate(m_ExplosionPrefab);
            explosion.transform.position = gameObject.transform.position;
            Destroy(explosion, 0.5f);

            Destroy(gameObject);
            m_EventOnDeath?.Invoke();
        }

    }

}
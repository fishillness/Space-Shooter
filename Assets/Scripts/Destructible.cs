using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    /// <summary>
    /// Destructible object on the stage. Something that can have hit points.
    /// Уничтожаемый объект на сцене. То что может иметь хитпоинты.
    /// </summary>
    public class Destructible : Entity
    {
        #region Properties
        /// <summary>
        /// The object ignores damage.
        /// Объект игнорирует повреждения.
        /// </summary>
        [SerializeField] private bool m_Indestructible;
        public bool IsIndestructible => m_Indestructible;

        /// <summary>
        /// Starting number of hitpoints.
        /// Стартовое кол-во хитпоинтов.
        /// </summary>
        [SerializeField] private int m_HitPoints;

        /// <summary>
        /// Current hitpoints.
        /// Текущие хитпоинты.
        /// </summary>
        int m_CurrentHitPoints;
        public int HitPoints => m_CurrentHitPoints;


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
        /// Применение урона к объекту.
        /// </summary>
        /// <param name="damage"> Damage dealt to an object. Урон наносимый объекту.</param>
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
        /// Переопределяемое событие уничтожения объекта, когда хитпоинты ниже или равны нулю.
        /// </summary>
        protected virtual void OnDeath()
        {
            Destroy(gameObject);
            m_EventOnDeath?.Invoke();


            /////////////////////////////////
             
        }

    }

}
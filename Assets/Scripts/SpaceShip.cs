using UnityEngine;

namespace SpaceShooter
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class SpaceShip : Destructible
    {
        /// <summary>
        /// Mass for automatic installation at rigidbody.
        /// Масса для автоматической установки у rigidbody.
        /// </summary>
        [Header("Space ship")]
        [SerializeField] private float m_Mass;

        /// <summary>
        /// Pushing force.
        /// Толкающая вперед сила.
        /// </summary>
        [SerializeField] private float m_Thrust;

        /// <summary>
        /// Rotating force.
        /// Вращающая сила.
        /// </summary>
        [SerializeField] private float m_Mobility;

        /// <summary>
        /// Maximum line speed.
        /// Максимальная линейная скорость.
        /// </summary>
        [SerializeField] private float m_MaxLinearVelocity;

        /// <summary>
        /// Maximum rotational speed. In degrees/sec
        /// Максимальная вращательная скорость. В градусах/сек
        /// </summary>
        [SerializeField] private float m_MaxAngularVelocity;


        /// <summary>
        /// Saved reference to rigidbody.
        /// Сохраненная ссылки на rigidbody.
        /// </summary>
        private Rigidbody2D m_Rigid;

        #region Public API

        /// <summary>
        /// Linear thrust control. -1.0 to +1.0.
        /// Управление линейной тягой. От -1.0 до +1.0.
        /// </summary>
        public float ThrustControl { get; set; }

        /// <summary>
        /// Rotary thrust control. -1.0 to +1.0.
        /// Управление вращательной тягой. От -1.0 до +1.0.
        /// </summary>
        public float TorqueControl { get; set; }

        #endregion

        #region Unity Event

        protected override void Start()
        {
            base.Start();

            m_Rigid = GetComponent<Rigidbody2D>();
            m_Rigid.mass = m_Mass;

            m_Rigid.inertia = 1;
        }

        private void FixedUpdate()
        {
            UpdateRigidbody();
        }


        #endregion

        /// <summary>
        /// Method for adding forces to the ship for movement.
        /// Метод добавления сил кораблю для движения.
        /// </summary>
        private void UpdateRigidbody()
        {
            m_Rigid.AddForce(ThrustControl * m_Thrust * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddForce(-m_Rigid.velocity * (m_Thrust / m_MaxLinearVelocity ) * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddTorque(TorqueControl * m_Mobility * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddTorque(-m_Rigid.angularVelocity * (m_Mobility / m_MaxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }

}
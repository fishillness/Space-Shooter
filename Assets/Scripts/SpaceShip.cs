using UnityEngine;

namespace SpaceShooter
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class SpaceShip : Destructible
    {
        /// <summary>
        /// Mass for automatic installation at rigidbody.
        /// ����� ��� �������������� ��������� � rigidbody.
        /// </summary>
        [Header("Space ship")]
        [SerializeField] private float m_Mass;

        /// <summary>
        /// Pushing force.
        /// ��������� ������ ����.
        /// </summary>
        [SerializeField] private float m_Thrust;

        /// <summary>
        /// Rotating force.
        /// ��������� ����.
        /// </summary>
        [SerializeField] private float m_Mobility;

        /// <summary>
        /// Maximum line speed.
        /// ������������ �������� ��������.
        /// </summary>
        [SerializeField] private float m_MaxLinearVelocity;

        /// <summary>
        /// Maximum rotational speed. In degrees/sec
        /// ������������ ������������ ��������. � ��������/���
        /// </summary>
        [SerializeField] private float m_MaxAngularVelocity;

        /// <summary>
        /// Saved reference to rigidbody.
        /// ����������� ������ �� rigidbody.
        /// </summary>
        private Rigidbody2D m_Rigid;

        //////////////////////////////////////////////////////////////////////////////////////////////
        private float m_TimeSpeedBoost;
        private bool isSpeedBoost;
        private float m_LinearVelocity;
        private float m_AngularVelocity;
        private float m_TimerSpeed;


        private float m_TimeIndestructibleBoost;
        private float m_TimerIndestructible;
        private bool isIndestructibleBoost;
        //////////////////////////////////////////////////////////////////////////////////////////////


        #region Public API

        /// <summary>
        /// Linear thrust control. -1.0 to +1.0.
        /// ���������� �������� �����. �� -1.0 �� +1.0.
        /// </summary>
        public float ThrustControl { get; set; }

        /// <summary>
        /// Rotary thrust control. -1.0 to +1.0.
        /// ���������� ������������ �����. �� -1.0 �� +1.0.
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
            
            

            //////////////////////////////////////////////////////////////////////////////////////////////
            isSpeedBoost = false;
            m_LinearVelocity = m_MaxLinearVelocity;
            m_AngularVelocity = m_MaxAngularVelocity;
            /////////////////////////////////////////////////////////////////////////////////////////////

            InitOffensive();
        }

        private void FixedUpdate()
        {
            UpdateRigidbody();
            UpdateEnergyRegen();


            /////////////////////////////////////////////////////////////////////////////////////////////
            ///

            if (isSpeedBoost == true)
            {
                if (m_TimerSpeed < m_TimeSpeedBoost)
                {
                    m_TimerSpeed += Time.deltaTime;
                }
                else
                {
                    isSpeedBoost = false;
                    m_LinearVelocity = m_MaxLinearVelocity;
                    m_AngularVelocity = m_MaxAngularVelocity;
                    m_TimerSpeed = 0;
                }
            }

            

            if(isIndestructibleBoost == true)
            {
                if (m_TimerIndestructible < m_TimeIndestructibleBoost)
                {
                    m_TimerIndestructible += Time.deltaTime;
                }
                else
                {
                    isIndestructibleBoost = false;
                    m_Indestructible = false;
                    m_TimerIndestructible = 0;
                }
            }

            /////////////////////////////////////////////////////////////////////////////////////////////
        }
        #endregion

        /// <summary>
        /// Method for adding forces to the ship for movement.
        /// ����� ���������� ��� ������� ��� ��������.
        /// </summary>
        private void UpdateRigidbody()
        {
            m_Rigid.AddForce(ThrustControl * m_Thrust * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);

            //m_Rigid.AddForce(-m_Rigid.velocity * (m_Thrust / m_MaxLinearVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddForce(-m_Rigid.velocity * (m_Thrust / m_LinearVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddTorque(TorqueControl * m_Mobility * Time.fixedDeltaTime, ForceMode2D.Force);

            //m_Rigid.AddTorque(-m_Rigid.angularVelocity * (m_Mobility / m_MaxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddTorque(-m_Rigid.angularVelocity * (m_Mobility / m_AngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
        }


        [SerializeField] private Turret[] m_Turrets;
        public void Fire(TurretMode mode)
        {
            for (int i = 0; i < m_Turrets.Length; i++)
            {
                if (m_Turrets[i].Mode == mode)
                {
                    m_Turrets[i].Fire();
                }
            }
        }

        #region Energy and Ammo
        /// <summary>
        /// Maximum energy value.
        /// ������������ ���������� �������.
        /// </summary>
        [SerializeField] private int m_MaxEnergy;
        /// <summary>
        /// Maximum ammo value.
        /// ������������ ���������� ������.
        /// </summary>
        [SerializeField] private int m_MaxAmmo;
        /// <summary>
        /// The amount of energy restored per second.
        /// ���������� ������� ����������������� � �������.
        /// </summary>
        [SerializeField] private int m_EnergyRegenPerSecond;

        /// <summary>
        /// Current energy value.
        /// ������� ���������� �������.
        /// </summary>
        private float m_PrimaryEnergy;
        /// <summary>
        /// Current ammo value.
        /// ������� ���������� ������.
        /// </summary>
        private int m_SecondaryAmmo;

        public void AddEnergy(int e)
        {
            m_PrimaryEnergy = Mathf.Clamp(m_PrimaryEnergy + e, 0, m_MaxEnergy);
        }
        public void AddAmmo(int ammo)
        {
            m_SecondaryAmmo = Mathf.Clamp(m_SecondaryAmmo + ammo, 0, m_MaxAmmo);

        }

        private void InitOffensive()
        {
            m_PrimaryEnergy = m_MaxEnergy;
            m_SecondaryAmmo = m_MaxAmmo;
        }

        private void UpdateEnergyRegen()
        {
            m_PrimaryEnergy += (float)m_EnergyRegenPerSecond * Time.fixedDeltaTime;
            m_PrimaryEnergy = Mathf.Clamp(m_PrimaryEnergy, 0, m_MaxEnergy);
        }

        public bool DrawAmmo(int count)
        {
            if (count == 0)
                return true;

            if (m_SecondaryAmmo >= count)
            {
                m_SecondaryAmmo -= count;
                return true;
            }

            return false;
        }

        public bool DrawEnergy(int count)
        {
            if (count == 0)
                return true;

            if (m_PrimaryEnergy >= count)
            {
                m_PrimaryEnergy -= count;
                return true;
            }

            return false;
        }

        public void AssignWeapon(TurretProperties props)
        {
            for (int i = 0; i < m_Turrets.Length; i++)
            {
                m_Turrets[i].AssignLoadout(props);
            }
        }

        #endregion


        //////////////////////////////////////////////////////////////////////////////////////////////
        public void IncreaseSpeed(float value, float time)
        {
            m_TimeSpeedBoost = time;
            m_AngularVelocity += value;
            m_LinearVelocity += value;
            isSpeedBoost = true;
        }

        public void BecameIndestructible(float time)
        {
            m_TimeIndestructibleBoost = time;
            m_Indestructible = true;
            isIndestructibleBoost = true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
    }

}
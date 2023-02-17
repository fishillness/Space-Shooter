using System;
using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(SpaceShip))]
    public class AIController : MonoBehaviour
    {
        #region Properties
        /// <summary>
        /// Types of AI behavior. Null - no behavior, Patrol - the ship will patrol.
        /// Типы поведения АИ. Null - нет поведения, Patrol - корабль потрулирует.
        /// </summary>
        public enum AIBehaviour
        {
            Null,
            Patrol
        }
        /// <summary>
        /// Store the behavior type.
        /// Хранение типа поведения.
        /// </summary>
        [SerializeField] private AIBehaviour m_AIBehaviour;
        /// <summary>
        /// Link to patrol zone.
        /// Ссылка на зону патрулирования.
        /// </summary>
        [SerializeField] private AIPointPatrol m_PatrolPoint;
        /// <summary>
        /// Movement speed.
        /// Скорость перемеещения.
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationLinear;
        /// <summary>
        /// Speed of development.
        /// Скорость вращения.
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationAngular;
        /// <summary>
        /// Time to change position.
        /// Время для изменения позиции.
        /// </summary>
        [SerializeField] private float m_RandomSelectMovePointTime;
        /// <summary>
        /// Time to change target.
        /// Время для изменения цели.
        /// </summary>
        [SerializeField] private float m_FindNewTargetTime;
        /// <summary>
        /// Shooting delay.
        /// Задержка стрельбы.
        /// </summary>
        [SerializeField] private float m_ShootDelay;
        /// <summary>
        /// Raycast length.
        /// Длина рейкаста.
        /// </summary>
        [SerializeField] private float m_EvadeRayLenght;

        private SpaceShip m_SpaceShip;
        private Vector3 m_MovePosition;
        private Destructible m_SelectedTarget;
        private Timer m_RandomizeDirectionTimer;
        #endregion

        #region Unity Events

        private void Start()
        {
            m_SpaceShip = GetComponent<SpaceShip>();
            InitTimers();
        }

        private void Update()
        {
            UpdateTimers();

            UpdateAI();
        }

        private void UpdateAI()
        {
            if (m_AIBehaviour == AIBehaviour.Null)
                return;

            if (m_AIBehaviour == AIBehaviour.Patrol)
            {
                UpdateBehaviourPatrol();
            }
        }

        private void UpdateBehaviourPatrol()
        {
            ActionFindNewMovePosition();
            ActionControlShip();
            ActionFindNewAttackTarget();
            ActionFire();
            ActionEvadeCollision();
        }
        private void ActionFindNewMovePosition()
        {
            if (m_AIBehaviour == AIBehaviour.Null)
                return;

            if (m_AIBehaviour == AIBehaviour.Patrol)
            {
                if(m_SelectedTarget != null)
                {
                    m_MovePosition = m_SelectedTarget.transform.position;
                }
                else
                {
                    if(m_PatrolPoint != null)
                    {
                        bool isInsidePatrolZone = (m_PatrolPoint.transform.position - transform.position).sqrMagnitude < m_PatrolPoint.Radius * m_PatrolPoint.Radius;
                        
                        if(isInsidePatrolZone == true)
                        {
                            if (m_RandomizeDirectionTimer.IsFinished)
                            {
                                Vector2 newPoint = UnityEngine.Random.onUnitSphere * m_PatrolPoint.Radius + m_PatrolPoint.transform.position;
                                m_MovePosition = newPoint;

                                m_RandomizeDirectionTimer.Start(m_RandomSelectMovePointTime);
                            }
                        }
                        else
                        {
                            m_MovePosition = m_PatrolPoint.transform.position;
                        }
                    }
                }
            }
        }

        private void ActionEvadeCollision()
        {
            if (Physics2D.Raycast(transform.position, transform.up, m_EvadeRayLenght) == true)
            {
                m_MovePosition = transform.position + transform.right * 100.0f;
            }
        }

        private void ActionControlShip()
        {
            m_SpaceShip.ThrustControl = m_NavigationLinear;
            m_SpaceShip.TorqueControl = ComputeAliginTorgueNormalized(m_MovePosition, m_SpaceShip.transform) * m_NavigationAngular;
        }

        private const float MAX_ANGLE = 45.0f;
        private static float ComputeAliginTorgueNormalized(Vector3 targetPosition, Transform ship)
        {
            Vector2 localTargetPosition = ship.InverseTransformPoint(targetPosition);
            float angle = Vector3.SignedAngle(localTargetPosition, Vector3.up, Vector3.forward);
            angle = Mathf.Clamp(angle, -MAX_ANGLE, MAX_ANGLE) / MAX_ANGLE;
            return -angle;
        }

        private void ActionFindNewAttackTarget()
        {

        }

        private void ActionFire()
        {

        }


        #endregion

        public void SetPatrolBehaviour(AIPointPatrol point)
        {
            m_AIBehaviour = AIBehaviour.Patrol;
            m_PatrolPoint = point;
        }

        #region Timers

        private void InitTimers()
        {
            m_RandomizeDirectionTimer = new Timer(m_RandomSelectMovePointTime);
        }

        private void UpdateTimers()
        {
            m_RandomizeDirectionTimer.RemoveTime(Time.deltaTime);
        }

        #endregion


        /*
        private Timer TestTimer;

        private void Start()
        {
            TestTimer = new Timer(3);   
        }

        private void Update()
        {
            TestTimer.RemoveTime(Time.deltaTime);

            if(TestTimer.IsFinished == true)
            {
                Debug.Log("Test");
                TestTimer.Start(3);
            }
        }
         */
    }
}

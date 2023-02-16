using UnityEngine;

namespace SpaceShooter
{
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
        #endregion

        #region Unity Events

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

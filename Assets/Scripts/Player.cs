using UnityEngine;

namespace SpaceShooter
{
    public class Player : SingletonBase<Player>
    {
        #region Properties
        /// <summary>
        /// Number of lives.
        /// Количество жизней.
        /// </summary>
        [SerializeField] private int m_NumLives;
        /// <summary>
        /// Link to the ship.
        /// Ссылка на корабль.
        /// </summary>
        [SerializeField] private SpaceShip m_Ship;
        /// <summary>
        /// Link to ship prefab.
        /// Ссылка на префаб корабля.
        /// </summary>
        [SerializeField] private GameObject m_PlayerShipPrefab;
        public SpaceShip ActiveShip => m_Ship;
        /// <summary>
        /// Link to the camera controller.
        /// Ссылка на контроллер камеры.
        /// </summary>
        [SerializeField] private CameraController m_CameraController;
        /// <summary>
        /// Link to the movement controller.
        /// Ссылка на контроллер движения.
        /// </summary>
        [SerializeField] private MovementController m_MovementController;
        #endregion

        #region Unity Events
        private void Start()
        {
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }

        private void OnShipDeath()
        {
            m_NumLives--;

            if(m_NumLives > 0)
                Respawn();
        }

        private void Respawn()
        {
            var newPlayerShip = Instantiate(m_PlayerShipPrefab);
            m_Ship = newPlayerShip.GetComponent<SpaceShip>();
            m_Ship.EventOnDeath.AddListener(OnShipDeath);                    ////

            m_CameraController.SetTarget(m_Ship.transform);
            m_MovementController.SetTargetShip(m_Ship);
        }
        #endregion

        #region Score
        public int Score { get; private set; }
        public int NumKills { get; private set; }
        public void AddKill()
        {
            NumKills++;
        }
        public void AddScore(int num)
        {
            Score += num;
        }
        
        #endregion
    }
}


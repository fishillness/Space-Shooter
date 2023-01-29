using UnityEngine;

namespace SpaceShooter
{
    public class Player : MonoBehaviour
    {
        #region Properties
        /// <summary>
        /// Number of lives.
        /// ���������� ������.
        /// </summary>
        [SerializeField] private int m_NumLives;
        /// <summary>
        /// Link to the ship.
        /// ������ �� �������.
        /// </summary>
        [SerializeField] private SpaceShip m_Ship;
        /// <summary>
        /// Link to ship prefab.
        /// ������ �� ������ �������.
        /// </summary>
        [SerializeField] private GameObject m_PlayerShipPrefab;
        /// <summary>
        /// Link to the camera controller.
        /// ������ �� ���������� ������.
        /// </summary>
        [SerializeField] private CameraController m_CameraController;
        /// <summary>
        /// Link to the movement controller.
        /// ������ �� ���������� ��������.
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
    }
}


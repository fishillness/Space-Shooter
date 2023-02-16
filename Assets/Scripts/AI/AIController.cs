using UnityEngine;

namespace SpaceShooter
{
    public class AIController : MonoBehaviour
    {
        /// <summary>
        /// 
        /// ���� ��������� ��. Null - ��� ���������, Patrol - ������� �����������.
        /// </summary>
        public enum AIBehaviour
        {
            Null,
            Patrol
        }
        /// <summary>
        /// 
        /// �������� ���� ���������.
        /// </summary>
        [SerializeField] private AIBehaviour m_AIBehaviour;
        /// <summary>
        /// 
        /// 
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationLinear;
        /// <summary>
        /// 
        /// 
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationAngular;
        /// <summary>
        /// 
        /// 
        /// </summary>
        [SerializeField] private float m_RandomSelectMovePointTime;
        /// <summary>
        /// 
        /// 
        /// </summary>
        [SerializeField] private float m_FindNewTargetTime;
        /// <summary>
        /// 
        /// 
        /// </summary>
        [SerializeField] private float m_ShootDelay;
        /// <summary>
        /// 
        /// 
        /// </summary>
        [SerializeField] private float m_EvadeRayLenght;
        /// <summary>
        /// 
        /// 
        /// </summary>
        private SpaceShip m_SpaceShip;
        /// <summary>
        /// 
        /// 
        /// </summary>
        private Vector3 m_MovePosition;
        /// <summary>
        /// 
        /// 
        /// </summary>
        private Destructible m_SelectedTarget;

    }

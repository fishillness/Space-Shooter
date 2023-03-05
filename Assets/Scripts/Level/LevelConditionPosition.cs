 using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionPosition : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private Transform m_pointTarget;
        [SerializeField] private float m_radiusPointProximity;
        private bool m_Reached;

        bool ILevelCondition.isCompleted
        {
            get
            {
                if (Player.Instance != null && Player.Instance.ActiveShip != null)
                {
                    bool isNearPointTarget = (m_pointTarget.position - Player.Instance.GetActiveShipPosition()).sqrMagnitude < m_radiusPointProximity * m_radiusPointProximity;
                    
                    if (isNearPointTarget == true)
                    {
                        m_Reached = true;
                        Debug.Log("Reached");
                    }
                }
                return m_Reached;
            }            
        }
    }
}


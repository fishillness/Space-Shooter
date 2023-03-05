using UnityEngine;

namespace SpaceShooter
{
    public class ConditionLevelScore : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private int score;
        private bool m_Reached;
        
        bool ILevelCondition.isCompleted
        {
            get
            {
                if(Player.Instance != null && Player.Instance.ActiveShip != null)
                {
                    if(Player.Instance.Score >= score)
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

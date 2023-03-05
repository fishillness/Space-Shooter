using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class LivesStats : MonoBehaviour
    {
        [SerializeField] private Text m_Text;
        private int m_LastNumLives;

        private void Update()
        {
            UpdateNumLives();
        }

        private void UpdateNumLives()
        {
            if (Player.Instance != null)
            {
                int currentNumLives = Player.Instance.NumLives;

                if (m_LastNumLives != currentNumLives)
                {
                    m_LastNumLives = currentNumLives;
                    m_Text.text = "Lives: " + m_LastNumLives.ToString();
                }
            }
        }
    }
}


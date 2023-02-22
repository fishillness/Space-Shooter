using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class GameStatisticsPanelController : MonoBehaviour
    {
        [SerializeField] private Text m_Kills;
        [SerializeField] private Text m_Score;
        [SerializeField] private Text m_Time;

        private void Start()
        {
            m_Kills.text = "Kills: " + GameStatistics.Instance.GameNumkills;
            m_Score.text = "Score: " + GameStatistics.Instance.GameScore;
            m_Time.text = "Time: " + GameStatistics.Instance.GameTime;
        }

        public void OnButtonMainMenu()
        {
            gameObject.SetActive(false);
            MainMenuController.Instance.gameObject.SetActive(true);
        }
    }
}



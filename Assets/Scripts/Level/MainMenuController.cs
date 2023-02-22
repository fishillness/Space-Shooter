using UnityEngine;

namespace SpaceShooter
{    public class MainMenuController : SingletonBase<MainMenuController>
    {
        [SerializeField] private SpaceShip m_DefaultSpaceShip;
        [SerializeField] private GameObject m_EpisodeSelection;
        [SerializeField] private GameObject m_ShipSelection;
        [SerializeField] private GameObject m_GameStatistics;

        private void Start()
        {
            LevelSequenceController.PlayerShip = m_DefaultSpaceShip;

            m_EpisodeSelection.SetActive(false);
            m_ShipSelection.SetActive(false);
            m_GameStatistics.SetActive(false);
        }

        public void OnButtonStartNew()
        {
            m_EpisodeSelection.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnButtonSelectShip()
        {
            m_ShipSelection.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnButtonGameStatistics()
        {
            m_GameStatistics.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnButtonExit()
        {
            Application.Quit();
        }
    }
}


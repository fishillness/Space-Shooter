using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{    
    public class LevelSequenceController : SingletonBase<LevelSequenceController>
    {
        public static string MainMenuSceneNickname = "Main menu";
        public Episode CurrentEpissode { get; private set; }
        public int CurrentLevel { get; private set; }

        public static SpaceShip PlayerShip { get; set; }

        public void StartEpisode(Episode e)
        {
            CurrentEpissode = e;
            CurrentLevel = 0;

            //сбросить статы перед началом эпизода

            SceneManager.LoadScene(e.Levels[CurrentLevel]);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(CurrentEpissode.Levels[CurrentLevel]);
        }

        public void FinishCurrentLevel(bool success)
        {
            if (success)
                AdvanceLevel();
        }

        public void AdvanceLevel()
        {
            CurrentLevel++;

            if (CurrentEpissode.Levels.Length <= CurrentLevel) ///!!!!!!!!!!!!!!1 
            {
                SceneManager.LoadScene(MainMenuSceneNickname);
            }
            else
            {
                SceneManager.LoadScene(CurrentEpissode.Levels[CurrentLevel]);
            }
        }
    }
}


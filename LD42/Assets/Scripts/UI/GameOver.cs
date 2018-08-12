using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text ScoreValText = null;


    private void Update()
    {
        ScoreValText.text = ScorePersistent.RecentScore.ToString("0");

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour {

    /* 
     * This is script for buttons in this game.
     * Every events after click on button you need write here. 
     */

	public void OnSceneLoadClick(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void OnStatisticsClick()
    {
        Debug.Log("Statistics button click");
    }

    public void OnAchievementClick()
    {
        Debug.Log("Achievements button click");
    }

    public void OnShareClick()
    {
        Debug.Log("Share button click");
    }

    public void OnPauseClick()
    {
        Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
    }
}

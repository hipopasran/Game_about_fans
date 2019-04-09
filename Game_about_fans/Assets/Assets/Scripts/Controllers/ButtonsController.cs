using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour {

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
}

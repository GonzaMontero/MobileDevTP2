using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonFunctions : MonoBehaviour
{
    public void EnableGameObject(GameObject go)
    {
        if (go.activeSelf) return;

        go.SetActive(true);
    }

    public void DisableGameObject(GameObject go)
    {
        if (!go.activeSelf) return;

        go.SetActive(false);
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}

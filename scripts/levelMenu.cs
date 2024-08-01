using UnityEngine;
using UnityEngine.SceneManagement;

public class levelMenu : MonoBehaviour
{
    public void openLevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadSceneAsync(levelName);
    }
}

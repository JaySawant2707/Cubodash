using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject controlBtns;
    [SerializeField] float GameOverDelay = 2f;
    bool gameHasEnded = false;
    PlayerCollision PC;
    private void Start()
    {
        PC = FindObjectOfType<PlayerCollision>();
    }
    public void gameOver()
    {
        if (!gameHasEnded && PC.isPlayerAlive==false)
        {
            gameHasEnded = true;
            Invoke("GOver", GameOverDelay);
        }    
    }

    public void GOver()
    {
        controlBtns.SetActive(false);
        gameOverScreen.SetActive(true);
        gameHasEnded = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PC.isPlayerAlive = true;
        Time.timeScale = 1;
        gameHasEnded = false;
    }

    public void pause()
    {
        controlBtns.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume()
    {
        controlBtns.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void lvl1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void nextLevelScr()
    {
        if (!gameHasEnded && PC.isPlayerAlive == true)
        {
            gameHasEnded = true;

            controlBtns.SetActive(false);

            winScreen.SetActive(true);

            gameHasEnded = false;
        }
    }

    public void nextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using TMPro;
using UnityEngine;

public class ScorehighUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    ScoreUI SC;

    private void Start()
    {
        SC = FindObjectOfType<ScoreUI>();
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }

    void Update()
    {
        PlayerPrefs.SetInt("Score", SC.number);
        scoreText.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }
}

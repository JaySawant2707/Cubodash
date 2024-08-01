using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] TMP_Text scoreText;
    public int number;

    PlayerCollision PC;

    private void Start()
    {
        PC = FindObjectOfType<PlayerCollision>();
    }

    void Update()
    {
        if (PC.isPlayerAlive)
        number += 1;

        scoreText.text = number.ToString("0");
    }
}

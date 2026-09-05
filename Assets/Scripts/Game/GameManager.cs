using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int playerOneScore = 0;
    private int playerTwoScore = 0;

    [SerializeField] private int winningScore = 5;  


    [SerializeField] private Transform puckSpawn;

    [SerializeField] private TMP_Text playerOneScoreText;
    [SerializeField] private TMP_Text playerTwoScoreText;
    [SerializeField] private GameObject winnerPanel;
    [SerializeField] private TMP_Text winnerText;

    private void Start()
    {
        winnerText.text = "";
        winnerPanel.SetActive(false);
    }

    public void AddScore(bool playerOneScored)
    {
        if (playerOneScored)
        {
            playerOneScore++;
            playerOneScoreText.text = playerOneScore.ToString();
            Debug.Log("P1 Score: " + playerOneScore);
        }
        else
        {
            playerTwoScore++;
            playerTwoScoreText.text = playerTwoScore.ToString();
            Debug.Log("P2 Score: " + playerTwoScore);
        }
        if (playerOneScore >= winningScore)
        {
            Debug.Log("PLAYER 1 WINS!");
            winnerText.text = "PLAYER 1 WINS!";
            winnerPanel.SetActive(true);
            return;
        }

        if (playerTwoScore >= winningScore)
        {
            Debug.Log("PLAYER 2 WINS!");
            winnerText.text = "PLAYER 2 WINS!";
            winnerPanel.SetActive(true);
            return;
        }

        ResetPuck();
    }



    private void ResetPuck()
    {
        GameObject puck = GameObject.FindGameObjectWithTag("Puck");

        puck.transform.position = puckSpawn.position;

        Rigidbody puckRb = puck.GetComponent<Rigidbody>();
        puckRb.linearVelocity = Vector3.zero;

        PuckController puckController =
        puck.GetComponent<PuckController>();

        puckController.Launch();

    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
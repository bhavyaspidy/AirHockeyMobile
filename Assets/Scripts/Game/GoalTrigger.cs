using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private bool playerOneGoal = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Puck"))
            return;

        GameManager gameManager =
            FindFirstObjectByType<GameManager>();

        if (playerOneGoal)
        {
            gameManager.AddScore(false);
        }
        else
        {
            gameManager.AddScore(true);
        }
    }
}
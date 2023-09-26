using UnityEngine;

[CreateAssetMenu(menuName = "Game/GameOverData")]
public class GameOver : ScriptableObject
{
    [Header("Game Over Text")]
    public string gameOverText = "Game Over!"; // Default game over text

    // You can add more fields here if needed.
}

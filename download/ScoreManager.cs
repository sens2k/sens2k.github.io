using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int value)
    {
        Score += 1;
    }


    private void OnDestroy()
    {
        Instance = null;
    }
}

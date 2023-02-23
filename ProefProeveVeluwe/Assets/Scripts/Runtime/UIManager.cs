using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("MainWindow");
    }

    public void Enter()
    {
        SceneManager.LoadScene("PettingMinigame");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void ToMiniGame()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void ToGPS()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}

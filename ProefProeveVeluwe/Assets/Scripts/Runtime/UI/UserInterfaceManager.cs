using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    void Start()
    {
        if(volumeSlider == null) return;
        volumeSlider.value = 0.5f;
        if (!PlayerPrefs.HasKey("soundVolume"))
        {
            PlayerPrefs.SetFloat("soundVolume", 0.5f);
            LoadVolume();
        }
        // else
        // {
        //     LoadVolume();
        // }
    }

    /// <summary>
    /// Makes sure the scene is loaded when you click on the button for the given level
    /// GIves the player the option to quit the game
    /// </summary>
    /// <param name="_loadNextScene"></param>

    public void LoadScene(string _loadNextScene)
    {
;
         SceneManager.LoadScene(_loadNextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Adjust the volume and remembers the preferable sound level for the player.
    /// </summary>

    public void AdjustVolume()
    {
        AudioListener.volume = volumeSlider.value;
        saveVolume();
    }

    private void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }

    private void saveVolume()
    {
        PlayerPrefs.SetFloat("soundVolume", volumeSlider.value);
    }
}

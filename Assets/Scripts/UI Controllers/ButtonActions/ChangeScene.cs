using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeButton : MonoBehaviour
{
    public Button changeSceneButton;
    public string targetSceneName;

    void Start()
    {
        // Add a listener to the button's onClick event
        changeSceneButton.onClick.AddListener(ChangeScene);
    }

    // Method to change the scene
    void ChangeScene()
    {
        SceneManager.LoadSceneAsync(targetSceneName);
    }
}

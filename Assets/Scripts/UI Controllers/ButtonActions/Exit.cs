using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    // Attach this to the Button component in the Inspector
    public Button exitButton;

    void Start()
    {
        // Add a listener to the button's onClick event
        exitButton.onClick.AddListener(ExitGame);
    }

    // This method will be called when the button is clicked
    void ExitGame()
    {
        // Close the application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

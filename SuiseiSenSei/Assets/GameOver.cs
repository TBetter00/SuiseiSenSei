
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            // Load the next scene (you can change the scene name or index as needed)
            SceneManager.LoadScene("Menu Scene");
        }
    }
}

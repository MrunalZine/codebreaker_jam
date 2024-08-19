using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransistionManager : MonoBehaviour
{
    public GameObject errorPanel; // Assign this in the Inspector
    public string newSceneName; // Assign this in the Inspector
    public GameObject targetGameObject; // Assign this in the Inspector

    private bool isCollidingWithTarget = false; // Tracks if the collision with the target GameObject is occurring

    void Start()
    {
        // Ensure the error panel is hidden at the start
        if (errorPanel != null)
        {
            errorPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Check for Enter key press
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isCollidingWithTarget)
            {
                // Load the new scene
                LoadNewScene();
            }
            else
            {
                // Show the error panel
                ShowErrorPanel();
            }
        }

        // Check for R key press to restart the scene
        if (Input.GetKeyDown(KeyCode.R) && errorPanel.activeSelf)
        {
            RestartScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the target GameObject
        if (collision.gameObject == targetGameObject)
        {
            isCollidingWithTarget = true; // Set to true to allow scene transition
            Debug.Log("Collided with target GameObject: isCollidingWithTarget = true");
        }
    }

    // Remove or comment out this method if you want the flag to stay true
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Optionally, you can remove or comment out this method
        // to ensure that isCollidingWithTarget remains true even when exiting the collision.
        if (collision.gameObject == targetGameObject)
        {
            // Commenting out the following line to keep the flag true
            // isCollidingWithTarget = false;
            Debug.Log("Exited collision with target GameObject: isCollidingWithTarget = false");
        }
    }

    private void LoadNewScene()
    {
        Debug.Log("Attempting to load new scene: " + newSceneName);
        // Load the scene assigned in the Inspector
        SceneManager.LoadScene(newSceneName);
    }

    private void ShowErrorPanel()
    {
        if (errorPanel != null)
        {
            errorPanel.SetActive(true);
        }
    }

    private void RestartScene()
    {
        if (errorPanel != null)
        {
            errorPanel.SetActive(false);
        }
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class VideoIntro : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string nextSceneName;
    public float delayBeforeTransition = 1.0f; // Delay after the video ends, in seconds
    private bool videoEnded = false;

    void Start()
    {
        // Ensure the VideoPlayer component is assigned
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer is not assigned. Please assign it in the inspector.");
            enabled = false; // Disable this script if VideoPlayer is not assigned
            return;
        }

        // Subscribe to the videoPlayer.loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;

        // Play the video
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // This function is called when the video finishes playing
        videoEnded = true;
        StartCoroutine(DelayedSceneLoad());
    }

    IEnumerator DelayedSceneLoad()
    {
        // Wait for the specified delay before loading the next scene
        yield return new WaitForSeconds(delayBeforeTransition);

        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }

    // Optional: Implement a manual skip with a key press (e.g., Spacebar)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !videoEnded)
        {
            // Stop the video and load the next scene immediately
            videoPlayer.Stop();
            StopAllCoroutines(); // Stop any existing coroutines
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
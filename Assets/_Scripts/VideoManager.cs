using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public VideoClip video;

    private void Start()
    {
        StartCoroutine(WaitForVideo());
    }

    IEnumerator WaitForVideo() 
    {
        yield return new WaitForSeconds((float)video.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

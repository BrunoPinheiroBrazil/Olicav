using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class PlayTV : MonoBehaviour
{
  public GameObject screenPlayer;
  public AudioSource ambientMusic;

  private VideoPlayer player;

  private void Start()
  {
    player = screenPlayer.GetComponent<VideoPlayer>();
  }

  private void OnMouseDown()
  {
    if (!screenPlayer.activeSelf)
    {
      screenPlayer.SetActive(true);
      ambientMusic.Stop();
      StartCoroutine(WaitVideoPlayer());
    }
  }

  private IEnumerator WaitVideoPlayer()
  {
    while (true)
    {
      yield return new WaitForSeconds(1.0f);
      if (!player.isPlaying)
      {
        screenPlayer.SetActive(false);
        ambientMusic.Play();
        break;
      }
    }
  }
}

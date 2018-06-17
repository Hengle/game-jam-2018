using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
  private float previousTime = 0;

  // Use this for initialization
  void Start()
  {
    previousTime = Time.time;
    GetComponent<Text>().text = "  -  " + GameGod.Instance.CurrentPoints + " PTS";

    var go = GameObject.Find("MusicBG");
    if (go != null)
      go.GetComponent<PlayableDirector>().Play();
  }


  void Update()
  {
    if (Input.anyKeyDown && previousTime < Time.time)
    {
      StartCoroutine(Load());
    }
  }

  private IEnumerator Load()
  {
    yield return SceneManager.UnloadSceneAsync("ScoreScreen");
    Destroy(GameObject.Find("MusicBG"));
    yield return SceneManager.LoadSceneAsync("PreIntro");
  }
}
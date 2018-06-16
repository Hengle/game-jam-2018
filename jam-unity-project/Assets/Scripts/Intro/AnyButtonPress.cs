using System.Collections;
using System.Collections.Generic;
using GamepadInput;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class AnyButtonPress : MonoBehaviour
{
    public PlayableDirector Pd;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.Any)
            || GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.Any)
            || GamePad.GetButtonDown(GamePad.Button.X, GamePad.Index.Any)
            || GamePad.GetButtonDown(GamePad.Button.Y, GamePad.Index.Any)
            || Input.anyKeyDown)
        {
            Pd.Play();
            StartCoroutine(Load());
        }
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds((float)Pd.duration);
        yield return SceneManager.UnloadSceneAsync("PreIntro");
        yield return SceneManager.LoadSceneAsync("Intro");
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using GamepadInput;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuItemSelector : MonoBehaviour
{
    public AudioClip MenuChanged;
    public AudioClip MenuSelected;
    
    public Vector3 P1;
    public Vector3 P2;
    public Vector3 P3;

    public SelectedMenuItem P1Menu;
    public SelectedMenuItem P2Menu;
    public SelectedMenuItem P3Menu;

    private bool _changed = false;
    private float _previousValue;

    private int _currentIndex = 1;

    private void Start()
    {
        UpdateState();
    }

    public void SetP1()
    {
        //transform.position = P1;

        P1Menu.SelectNormal();
        P2Menu.Deselect();
        P3Menu.Deselect();
    }

    public void SetP2()
    {
        //transform.position = P2;

        P1Menu.Deselect();
        P2Menu.SelectNormal();
        P3Menu.Deselect();
    }

    public void SetP3()
    {
        //transform.position = P3;

        P1Menu.Deselect();
        P2Menu.Deselect();
        P3Menu.SelectNormal();
    }

    public void Update()
    {
        //if (GamePad.GetButtonDown(GamePad.GetButton(Bu GamePad.Index.Any))
        //{
        //    Debug.Log("Activate_P" + ((int)_playerIndex + 1));
        //    action = true;
        //}

        if (!_locked)
        {

            if (_changed)
            {
                PlayMenuItemChangeSound();
                _changed = false;
                if (_previousValue > 0)
                {
                    _currentIndex += 1;
                    if (_currentIndex > 3)
                    {
                        _currentIndex = 1;
                    }
                    UpdateState();
                }

                if (_previousValue < 0)
                {
                    _currentIndex--;
                    if (_currentIndex < 1)
                    {
                        _currentIndex = 3;
                    }
                    UpdateState();
                }
            }
        }

        if (GamePad.GetButtonDown(GamePad.Button.A, GamePad.Index.Any)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.Return))
        {
            _locked = true;
            BlinkFaster();
            StartCoroutine(LoadNextLevel());
            PlaySelected();
        }
    }

    private void PlaySelected()
    {
        var audio  = GetComponent<AudioSource>();
        audio.Stop();
        audio.clip = MenuSelected;
        audio.Play();
    }

    private void PlayMenuItemChangeSound()
    {
        var audio  = GetComponent<AudioSource>();
        audio.Stop();
        audio.clip = MenuChanged;
        audio.Play();
    }

    private bool _locked;

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2);
        yield return SceneManager.UnloadSceneAsync("Intro");
        yield return SceneManager.LoadSceneAsync("SplitScreenScene");
    }

    private void UpdateState()
    {
        switch (_currentIndex)
        {
            case 1:
                SetP1();
                break;

            case 2:
                SetP2();
                break;

            case 3:
                SetP3();
                break;
        }
    }

    private void BlinkFaster()
    {
        if (P1Menu.IsBlinking)
        {
            P1Menu.Select();
        }

        if (P2Menu.IsBlinking)
        {
            P2Menu.Select();
        }

        if (P3Menu.IsBlinking)
        {
            P3Menu.Select();
        }
    }
}
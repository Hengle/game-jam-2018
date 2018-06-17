using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class GameGod : MonoBehaviour
{
  private static GameGod _instance;

  public static GameGod Instance
  {
    get { return _instance; }
  }

  public int RepaireKeyPower = 3;

  public int RepaireKeyDecrement = 9;

  public event Action Updated = delegate { };

  public float NavigationEnergyConsumption = 3;
  public float NavigationEnergyTimeOut = 1;

  public float EnergyIncrement;
  public float Energy;
  public float MaximumEnergy;

  public int BulletsIncrement = 10;
  public int CurrentBullets = 10;
  public int MaximumBullets = 10;

  public AudioSource EnergySound;
  public AudioSource DeniedSource;
  public AudioSource NavigationRoomActivated;

  public AudioClip ShieldActivatedTrack;

  public int CurrentPoints = 0;

  public Text ScoreText;

  private bool _canPlaySound;

  public void Update()
  {
    if (Energy > 5)
    {
      _canPlaySound = true;
    }

    if (Energy < 5 && _canPlaySound)
    {
      _canPlaySound = false;
      EnergySound.Play();
    }

    if(ScoreText != null)
    ScoreText.text = CurrentPoints.ToString();
  }

  private void Awake()
  {
    CurrentPoints = 0;
    _instance = this;

    DontDestroyOnLoad(gameObject);
  }

  public float ShieldActivationEnergy = 20;
  public bool ShieldIsActivated;

  public void AddEnergy()
  {
    Energy += EnergyIncrement;
    if (Energy > MaximumEnergy)
    {
      Energy = MaximumEnergy;
    }
  }

  public void ActivateShield()
  {
		if (ShieldIsActivated)
			return;

    if (Energy > ShieldActivationEnergy)
    {
      ShieldIsActivated = true;
      Energy -= ShieldActivationEnergy;
      var audio = GetComponent<AudioSource>();
      audio.clip = ShieldActivatedTrack;
      audio.Play();
    }
    else
    {
      DeniedSource.Play();
    }

    Updated();
  }

  public void DeactivateShield()
  {
    ShieldIsActivated = false;
    Updated();
  }

  public void AddBullets()
  {
    CurrentBullets += BulletsIncrement;
    if (CurrentBullets > MaximumBullets)
      CurrentBullets = MaximumBullets;
  }

  public void AddScore(int score)
  {
    CurrentPoints += score;
  }

  public void RoomActivated(int roomNum)
  {
    switch (roomNum)
    {
        case 0:
          NavigationRoomActivated.Play();
          break;
    }
  }

  public void GameOver()
  {
    Destroy(GameObject.FindGameObjectWithTag("Player"));
    StartCoroutine(WaitAndLoad());
  }

  private IEnumerator WaitAndLoad()
  {
    yield return new WaitForSeconds(3);
    
    SceneManager.LoadScene("ScoreScreen");
  }
}
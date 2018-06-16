using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{

	public Image ProhressBar;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateUi();
	}

	void UpdateUi()
	{
		var showValue = GameGod.Instance.Energy / 100 * 0.5f;
		ProhressBar.fillAmount = showValue;
	}
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectedMenuItem : MonoBehaviour
{
    public Color DefaultColor;

    public Color BlinkColor;
    public float BlinkSpeed;
    public float NormalSpeed;

    private Text _text;

    private float _speed;

    public bool IsBlinking;

    // Use this for initialization
    private void Start()
    {
        _text = GetComponent<Text>();
        SelectNormal();
    }

    public void Select()
    {
        IsBlinking = true;
        _speed = BlinkSpeed;
        StartCoroutine("ChangeColor");
    }

    public void SelectNormal()
    {
        IsBlinking = true;
        _speed = NormalSpeed;
        StartCoroutine("ChangeColor");
    }

    public void Deselect()
    {
        IsBlinking = false;
        StopCoroutine("ChangeColor");
        _text.color = DefaultColor;
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            _text.color = BlinkColor;
            yield return new WaitForSeconds(_speed);
            _text.color = DefaultColor;
            yield return new WaitForSeconds(_speed);
        }
    }
}
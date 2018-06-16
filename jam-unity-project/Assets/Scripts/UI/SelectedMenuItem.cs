using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectedMenuItem : MonoBehaviour
{
    public Color DefaultColor;

    public Color BlinkColor;
    public Color SelectedBlinkColor;
    public float BlinkSpeed;
    public float NormalSpeed;

    private Text _text;

    private float _speed;
    private Color _color;

    public bool IsBlinking;

    // Use this for initialization
    private void Awake()
    {
        _text = GetComponent<Text>();
        SelectNormal();
    }

    public void Select()
    {
        _color = SelectedBlinkColor;
        IsBlinking = true;
        _speed = BlinkSpeed;
        StartCoroutine("ChangeColor");
    }

    public void SelectNormal()
    {
        _color = BlinkColor;
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
            _text.color = _color;
            yield return new WaitForSeconds(_speed);
            _text.color = DefaultColor;
            yield return new WaitForSeconds(_speed);
        }
    }
}
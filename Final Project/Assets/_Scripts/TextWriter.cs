using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : Singleton<TextWriter>
{
    [SerializeField] private float timeBetweenChars;
    private float lastCharTime = Mathf.NegativeInfinity;

    [HideInInspector] public bool isWriting = false;

    public void WriteSomething(string _text, TextMeshProUGUI _textMeshPro)
    {
        StopAllCoroutines();
        StartCoroutine(Write(_text, _textMeshPro));
    }

    IEnumerator Write(string _text, TextMeshProUGUI _textMeshPro)
    {
        isWriting = true;

        char[] text = _text.ToCharArray();

        _textMeshPro.text = "";

        foreach (char c in text)
        {
            _textMeshPro.text = _textMeshPro.text + c;
            yield return new WaitForSeconds(timeBetweenChars);
        }

        isWriting = false;
    }
}

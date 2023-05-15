using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextWriter : Singleton<TextWriter>
{
    [SerializeField] private float timeBetweenChars;
    private float lastCharTime = Mathf.NegativeInfinity;

    [HideInInspector] public bool isWriting = false;

    private string currentText;
    private TextMeshProUGUI currentTextMeshPro = null;

    public void WriteSomething(string _text, TextMeshProUGUI _textMeshPro)
    {
        StopAllCoroutines();
        StartCoroutine(Write(_text, _textMeshPro));
    }

    IEnumerator Write(string _text, TextMeshProUGUI _textMeshPro)
    {
        isWriting = true;

        currentText = _text;
        currentTextMeshPro = _textMeshPro;

        char[] text = _text.ToCharArray();

        _textMeshPro.text = "";

        foreach (char c in text)
        {
            _textMeshPro.text = _textMeshPro.text + c;
            yield return new WaitForSeconds(timeBetweenChars);
        }

        currentText = "";
        currentTextMeshPro = null;

        isWriting = false;
    }

    public void WriteItInstant()
    {
        StopAllCoroutines();
        isWriting = false;
        currentTextMeshPro.text = currentText;

        currentText = "";
        currentTextMeshPro = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : Singleton<QuizManager>
{
    public GameObject optionPrefab;
    public GameObject optionsContainer;

    public TextMeshProUGUI questionText;
    public List<Button> Options = new List<Button>();

    public void AddOption(int _id, string _text)
    {
        GameObject option = Instantiate(optionPrefab);
        option.name = _id.ToString();
        option.transform.parent = optionsContainer.transform;
        option.GetComponentInChildren<TextMeshProUGUI>().text = _text;
        Options.Add(option.GetComponent<Button>());
    }

    public void StartQuiz(Quiz _quiz)
    {
        questionText.text = _quiz.question;

        foreach (var item in Options)
        {
            Destroy(item.gameObject);
        }

        Options.Clear();

        for (int i = 0; i < _quiz.answers.Count; i++)
        {
            AddOption(i, _quiz.answers[i]);
        }
    }
}

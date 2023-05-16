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

    private Quiz currentQuiz = new Quiz();

    private bool isQuizDone = false;

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
        isQuizDone = false;
        currentQuiz = _quiz;

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

    public void Choose(int _id)
    {
        if (isQuizDone) return;

        if (currentQuiz.correctAnswerID == _id)
        {
            // DO�RU
            // Buton Ye�il Parlar

            Options[_id].GetComponent<Image>().color = Color.green;

            isQuizDone = true;

            StartCoroutine(EndQuiz());
        }
        else
        {
            // YANLI�
            // Button K�rm�z� Parlar
            
            Options[_id].GetComponent<Image>().color = Color.red;
        }
    }

    private IEnumerator EndQuiz()
    {
        yield return new WaitForSeconds(1.5f);

        LessonManager.Instance.QuizPage.SetActive(false);

        LessonManager.Instance.NextPage();
    }
}

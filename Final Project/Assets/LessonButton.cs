using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LessonButton : MonoBehaviour
{
    public TextMeshProUGUI lessonNameTMP;

    public void Click()
    {
        int id = int.Parse(gameObject.name);

        LessonManager.Instance.currentLesson = LessonListManager.Instance.lessonList[id];

        MenuController.Instance.OpenMenu("LessonPage");

        LessonManager.Instance.StartLesson();
    }

    public void Initialize(Lesson _lesson)
    {
        lessonNameTMP.text = _lesson.lessonName;
    }
}

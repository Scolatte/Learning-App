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
        // Open Lesson by its id

        MenuController.Instance.OpenMenu("LessonPage");
    }

    public void Initialize(Lesson _lesson)
    {
        lessonNameTMP.text = _lesson.lessonName;
    }
}

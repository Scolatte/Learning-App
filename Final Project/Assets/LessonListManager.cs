using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonListManager : Singleton<LessonListManager>
{
    public GameObject lessonButtonPrefab;
    public GameObject containerGO;

    public List<Lesson> lessonList = new List<Lesson>();

    public void InitializeLessons()
    {
        for (int i = 0; i < lessonList.Count; i++)
        {

        }
    }
}

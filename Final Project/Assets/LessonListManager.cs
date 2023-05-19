using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonListManager : Singleton<LessonListManager>
{
    public GameObject lessonButtonPrefab;
    public GameObject containerGO;

    public List<Lesson> lessonList = new List<Lesson>();

    public void Start()
    {
        InitializeLessons();
    }

    public void InitializeLessons()
    {
        RectTransform r = containerGO.GetComponent<RectTransform>();
        VerticalLayoutGroup layoutGroup = containerGO.GetComponentInParent<VerticalLayoutGroup>();

        float calculatedHeight = 
            layoutGroup.padding.top 
            + layoutGroup.padding.bottom 
            + layoutGroup.spacing * (lessonList.Count - 1) 
            + lessonList.Count * lessonButtonPrefab.GetComponent<RectTransform>().sizeDelta.y;

        r.sizeDelta = new Vector2(r.sizeDelta.x, calculatedHeight);

        for (int i = 0; i < lessonList.Count; i++)
        {
            GameObject go = Instantiate(lessonButtonPrefab);
            go.name = i.ToString();

            go.transform.parent = containerGO.transform;

            go.GetComponent<LessonButton>().Initialize(lessonList[i]);
        }
    }
}

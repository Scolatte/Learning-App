using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonListManager : Singleton<LessonListManager>
{
    public GameObject lessonButtonPrefab;
    public GameObject lessonButtonLockPrefab;
    public GameObject containerGO;

    public List<Lesson> lessonList = new List<Lesson>();

    public List<RectTransform> lessonButtonsRTs = new List<RectTransform>();

    public void InitializeLessons()
    {
        //Clearing
        foreach (RectTransform rt in lessonButtonsRTs)
        {
            Destroy(rt.gameObject);
        }
        lessonButtonsRTs.Clear();

        //Calculating
        RectTransform r = containerGO.GetComponent<RectTransform>();
        VerticalLayoutGroup layoutGroup = containerGO.GetComponentInParent<VerticalLayoutGroup>();

        float calculatedHeight = 
            layoutGroup.padding.top 
            + layoutGroup.padding.bottom 
            + layoutGroup.spacing * (lessonList.Count - 1) 
            + lessonList.Count * lessonButtonPrefab.GetComponent<RectTransform>().sizeDelta.y;

        r.sizeDelta = new Vector2(r.sizeDelta.x, calculatedHeight);

        //Creating
        for (int i = 0; i < lessonList.Count; i++)
        {
            if (DataManager.Instance.IsLessonUnlocked(i))
            {
                // Lesson

                GameObject go = Instantiate(lessonButtonPrefab);
                go.name = i.ToString();

                go.transform.parent = containerGO.transform;

                go.GetComponent<LessonButton>().Initialize(lessonList[i]);

                lessonButtonsRTs.Add(go.GetComponent<RectTransform>());
            }
            else
            {
                // Lock

                GameObject go = Instantiate(lessonButtonLockPrefab);
                go.transform.parent = containerGO.transform;
                lessonButtonsRTs.Add(go.GetComponent<RectTransform>());
            }
            
        }
    }
}

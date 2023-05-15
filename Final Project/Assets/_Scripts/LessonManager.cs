using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LessonManager : Singleton<LessonManager>
{
    public GameObject Container;

    public Lesson currentLesson = null;

    [HideInInspector] public bool isOnLesson = false;
    [HideInInspector] public bool isOnPage = false;

    public int currentPageID = 0;
    public int currentPartID = 0;

    public void AddToContainer(LessonPart part)
    {
        if (TextWriter.Instance.isWriting) return;

        GameObject g = new GameObject("item" + Random.Range(1, 1000));
        g.transform.parent = Container.transform;
       
        g.AddComponent<RectTransform>();
        g.AddComponent<CanvasRenderer>();

        if (part.image != null)
        {
            g.AddComponent<Image>();
            g.GetComponent<Image>().sprite = part.image;
           
        }
        else if (part.Text != "")
        {
            g.AddComponent<TextMeshProUGUI>();

            TextWriter.Instance.WriteSomething(part.Text, g.GetComponent<TextMeshProUGUI>());

            g.GetComponent<TextMeshProUGUI>().color = Color.black;
            g.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Justified;

            g.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 22 + (part.Text.ToCharArray().Length/30) * 22);

            g.GetComponent<TextMeshProUGUI>().fontSize = 18;
        }

        RectTransform r = Container.GetComponent<RectTransform>();
        r.sizeDelta = new Vector2(r.sizeDelta.x, Container.transform.childCount * 110f);

        Debug.Log("Container Added");

        currentPartID++;
    }

    public void ScreenTap()
    {
        NextPart();
    }

    private void Update()
    {
        Cheats();
    }

    public void StartLesson()
    {
        Debug.Log("Lesson Started");
        //MenuController.Instance.OpenMenu("LessonPage");

        isOnLesson = true;
        StartPage(currentLesson.pages[0]);

        
    }

    public void EndLesson()
    {
        isOnLesson = false;
    }

    public void StartPage(LessonPage _page)
    {
        Debug.Log("Page Started");

        isOnPage = true;

        switch (_page.type)
        {
            case PageType.Lesson:
                AddToContainer(currentLesson.pages[currentPageID].parts[0]);
                break;
            case PageType.Quiz:
                //Ekrana Quizi Getircek
                break;
            default:
                break;
        }
    }

    public void NextPage()
    {
        currentPageID++;
        StartPage(currentLesson.pages[currentPageID]);
    }

    public void NextPart()
    {
        if (currentLesson.pages[currentPageID].parts.Count == currentPartID)
        {
            EndPage();
            return;
        }

        AddToContainer(currentLesson.pages[currentPageID].parts[currentPartID]);
    }

    public void EndPage()
    {
        isOnPage = false;
        currentPartID = 0;
        NextPage();
    }

    private void Cheats()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddToContainer(currentLesson.pages[0].parts[0]);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            AddToContainer(currentLesson.pages[0].parts[1]);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            AddToContainer(currentLesson.pages[0].parts[4]);
        }
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LessonManager : Singleton<LessonManager>
{
    public GameObject Container;

    public Lesson currentLesson = null;

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
    }

    private void Update()
    {
        Cheats();
    }

    IEnumerator LessonSession()
    {
        // Start Of lesson
        yield return new WaitForSeconds(2);

        // End Of Lesson
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
        else if (Input.GetKeyDown(KeyCode.F))
        {
            AddToContainer(currentLesson.pages[0].parts[3]);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            AddToContainer(currentLesson.pages[0].parts[2]);
        }
    }
}

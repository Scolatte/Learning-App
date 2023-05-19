using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonButton : MonoBehaviour
{
    public void Click()
    {
        

        MenuController.Instance.OpenMenu("LessonPage");
    }
}

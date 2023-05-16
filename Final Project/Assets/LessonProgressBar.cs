using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonProgressBar : Singleton<LessonProgressBar>
{
    public float spaceBetween = 5f;

    public RectTransform temp, temp1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            CalculatePositions(new List<RectTransform>() { temp, temp1 });
        }
    }

    public void CalculatePositions(List<RectTransform> _rectTransforms)
    {
        Debug.Log("MÝN = " + _rectTransforms[0].offsetMin.x);
        Debug.Log("Max = " + _rectTransforms[0].offsetMax.x);
    }
}

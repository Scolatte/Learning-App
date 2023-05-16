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
        //Debug.Log("MÝN = " + _rectTransforms[0].offsetMin.x);
        //Debug.Log("Max = " + -_rectTransforms[0].offsetMax.x);

        //Debug.Log("MÝN = " + _rectTransforms[1].offsetMin.x);
        //Debug.Log("Max = " + -_rectTransforms[1].offsetMax.x);

        for (int i = 0; i < _rectTransforms.Count; i++)
        {
            float left = 0f;
            float right = 0f;

            _rectTransforms[i].offsetMin = new Vector2(left ,_rectTransforms[i].offsetMin.y);
            _rectTransforms[i].offsetMax = new Vector2(-right, _rectTransforms[i].offsetMax.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonProgressBar : Singleton<LessonProgressBar>
{

    public GameObject progressBarItemPrefab;

    public float spaceBetween = 5f;

    public List<RectTransform> rectTransforms = new List<RectTransform>();

    // Hangi Sayfada isek belirgin olacak
    public void SetCurrentPage(int _currentPageID)
    {
        foreach (var item in rectTransforms)
        {
            item.GetComponent<Image>().color = rectTransforms[rectTransforms.Count - 1].GetComponent<Image>().color;
        }

        rectTransforms[_currentPageID].GetComponent<Image>().color = Color.white;
    }

    public void SetBarItems(int _pageCount)
    {
        rectTransforms.Clear();

        for (int i = 0; i < _pageCount; i++)
        {
            GameObject g = Instantiate(progressBarItemPrefab);

            g.transform.parent = transform;

            RectTransform rect = g.GetComponent<RectTransform>();

            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;

            rectTransforms.Add(rect);
        }

        CalculatePositions(rectTransforms);
    }

    public void CalculatePositions(List<RectTransform> _rectTransforms)
    {
        //Debug.Log("MÝN = " + _rectTransforms[0].offsetMin.x); LEFT
        //Debug.Log("Max = " + -_rectTransforms[0].offsetMax.x); -RIGHT

        //Debug.Log("MÝN = " + _rectTransforms[1].offsetMin.y); BOTTOM
        //Debug.Log("Max = " + -_rectTransforms[1].offsetMax.y); -TOP 

        float fullwidth = GetComponent<RectTransform>().sizeDelta.x;

        float spacesSum = (_rectTransforms.Count - 1) * spaceBetween;
        float calculatedWidth = (fullwidth - spacesSum)/(float)_rectTransforms.Count;

        for (int i = 0; i < _rectTransforms.Count; i++)
        {

            float left = i * (calculatedWidth + spaceBetween);
            float right = fullwidth - (spaceBetween * i + calculatedWidth * (1 + i));

            _rectTransforms[i].offsetMin = new Vector2(left ,_rectTransforms[i].offsetMin.y);
            _rectTransforms[i].offsetMax = new Vector2(-right, _rectTransforms[i].offsetMax.y);
        }
    }
}

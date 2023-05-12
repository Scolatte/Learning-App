using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newLeeson", menuName = "Data/Lesson")]
public class Lesson : ScriptableObject
{
    public string lessonName;

    public List<LessonPage> pages;
}

[System.Serializable]
public struct LessonPage
{
    public PageType type;

    public Quiz quiz;

    public List<LessonPart> parts;
}

[System.Serializable]
public struct LessonPart
{
    [Multiline]
    public string Text;
    public Sprite image;
}

[System.Serializable]
public struct Quiz
{
    [Multiline] public string question;
    public int correctAnswerID;
    [Multiline] public List<string> answers;
}

public enum PageType
{
    Lesson,
    Quiz
}

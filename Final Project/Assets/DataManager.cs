using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public void SaveLessonLock(int _lessonID, bool _isUnlocked)
    {
        string t = "Lesson" + _lessonID.ToString();

        if(_isUnlocked) PlayerPrefs.SetInt(t, 1);
        else PlayerPrefs.SetInt(t, 0);
    }

    public bool IsLessonUnlocked(int _id)
    {
        try
        {
            if (PlayerPrefs.GetInt("Lesson" + _id.ToString()) == 1)
                return true;
            else
                return false;
        }
        catch
        {
            Debug.Log("Ders Kayýdý Bulunamadý");
            return false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RefreshAllLessonSaves();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            MenuController.Instance.OpenMenu("MainMenu");
        }
    }

    public void RefreshAllLessonSaves()
    {
        PlayerPrefs.DeleteAll();

        for (int i = 0; i < LessonListManager.Instance.lessonList.Count; i++)
        {
            SaveLessonLock(i, false);
        }

        SaveLessonLock(0, true);

        Debug.Log("Bütün Kayýtlar Yenilendi");
    } 
}

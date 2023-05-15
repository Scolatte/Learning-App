using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public void Choose()
    {
        int id = int.Parse(gameObject.name);

        QuizManager.Instance.Choose(id);
    }
}

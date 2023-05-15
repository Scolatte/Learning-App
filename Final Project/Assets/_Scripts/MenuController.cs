using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MenuController : Singleton<MenuController>
{
    public List<Menu> menus = new List<Menu>();

    public void OpenMenu(string menuName)
    {
        foreach (Menu m in menus)
        {
            m.gameObject.SetActive(false);

            if (m.MenuName == menuName)
            {
                m.gameObject.SetActive(true);
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        foreach(Menu m in menus)
             m.gameObject.SetActive(false);

        menu.gameObject.SetActive(true);
    }
}

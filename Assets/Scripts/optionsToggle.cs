using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsToggle : MonoBehaviour {



    public void MenuToggle(GameObject menu)
    {

        if (menu.activeInHierarchy)
            menu.SetActive(false);
        else
            menu.SetActive(true);


    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplayController : MonoBehaviour
{
    public TMP_Text textComponent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Get values for status display. These are mostly static variables in other classes
        bool mouseModeActive = PlayerController.moveWithCamera;
        int eggsOnScreen = PlayerController.numberOfEggs;
        int enemyCount = SpawnManager.numberOfPlanes;
        int enemyDestroyed = SpawnManager.destroyedPlanes;
        String drive = null;

        if (mouseModeActive)
        {
            drive = "Mouse";
        } else
        {
            drive = "Key";
        }

        // Display text
        textComponent.text = "Hero: Drive(" + drive +")       EGG: OnScreen(" + eggsOnScreen + ")       Enemy: Count(" + enemyCount + ") Destroyed(" + enemyDestroyed + ")";
    }
}

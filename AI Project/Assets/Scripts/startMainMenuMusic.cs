using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMainMenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindAnyObjectByType<SoundManager>().Play("mainMenuSound");
    }

}

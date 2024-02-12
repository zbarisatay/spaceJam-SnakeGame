using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGoundMusic : MonoBehaviour
{
    private static backGoundMusic backgoundMusic;
    private void Awake()
    {
        if(backgoundMusic == null)
        {
            backgoundMusic = this;
            DontDestroyOnLoad(backgoundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

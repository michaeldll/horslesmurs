using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            changeCurScene();
        }
    }

    void changeCurScene()
    {
        SceneManager.LoadScene(1);
    }
}

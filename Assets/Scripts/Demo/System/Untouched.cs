using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Untouched : MonoBehaviour
{
    [SerializeField] GameObject slomo;
    [SerializeField] GameObject timer;

    void Update()
    {
#if !UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            slomo.SetActive(false);
            timer.SetActive(true);
            Time.timeScale = 1f;
        }

        if (Input.touchCount == 0)
        {
            slomo.SetActive(true);
            timer.SetActive(false);
            Time.timeScale = 0.2f;
        }

#endif

    }
}

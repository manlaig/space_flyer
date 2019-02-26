using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public void GoToLevel(string level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }

}

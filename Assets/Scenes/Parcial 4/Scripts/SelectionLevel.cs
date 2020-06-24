using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectionLevel : MonoBehaviour
{
    public void GoToLoadLevl()
    {
        SceneManager.LoadScene(1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(2);
    }

    public void GiveUp()
    {
        SceneManager.LoadScene(0);
    }
}

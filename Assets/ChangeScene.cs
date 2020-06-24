using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
   public void GoToMainMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void lvl1()
    {
        SceneManager.LoadScene(4);
    }
    public void lvl2()
    {
        SceneManager.LoadScene(2);
    }
    public void lvl3()
    {
        SceneManager.LoadScene(5);
    }
}

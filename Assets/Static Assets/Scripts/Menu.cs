using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Scenes(int numberScenes)
    {
        SceneManager.LoadScene(numberScenes);
    }

    public void Options()
    {

    }

    public void Quit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}

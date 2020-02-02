using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string name;


     public void LoadLevel()
    {
        SceneManager.LoadScene(this.name);
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}

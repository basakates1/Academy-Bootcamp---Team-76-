using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("LastScene",SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLastScene(){
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastScene",1));
    }

}

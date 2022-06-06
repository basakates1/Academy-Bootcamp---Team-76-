using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int levelCounter=0;

    private void Start() {
        levelCounter=PlayerPrefs.GetInt("LevelCounter",0);
    }

    public void LoadNextLevel()
    {
        levelCounter++;
        PlayerPrefs.SetInt("LevelCounter",levelCounter);

        if (levelCounter<10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (levelCounter>=10){
            SceneManager.LoadScene(Random.Range(1,10));
        }
    }
}

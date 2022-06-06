using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject[] musicObjects;
 
     void Start()
    {
        musicObjects= GameObject.FindGameObjectsWithTag("Music");

        if(musicObjects.Length>1){
            for (int i = musicObjects.Length-1; i > 0 ; i--)
            {
                Destroy(musicObjects[i]);
            }
        }

        DontDestroyOnLoad(gameObject);

        if(PlayerPrefs.GetInt("SoundOn",1)==1){
            
            if(!audioSource.isPlaying)
            audioSource.Play();
        }
        if(PlayerPrefs.GetInt("SoundOn",1)==0){
            
            audioSource.Stop();
        }
    }
}

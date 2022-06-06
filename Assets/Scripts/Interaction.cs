using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public bool canVibrate;
    public bool soundOn;
    private int canVibratePlayerPrefs;
    private int soundOnPlayerPrefs;
    public float pushForce = 1.5f;
    public List<Transform> other = new List<Transform>();
    [SerializeField] List<Rigidbody> _rb = new List<Rigidbody>();

    [SerializeField] List<float> dist = new List<float>();
    public List<Vector3> dir = new List<Vector3>();
    private AudioSource animalSound;
    public GameMusic gameMusic;

    public Image toggleImage;
    public Image soundToggleImage;
    void Start()
    {
        gameMusic=GameObject.FindWithTag("Music").GetComponent<GameMusic>();
        canVibratePlayerPrefs = PlayerPrefs.GetInt("CanVibrate", 1);
        soundOnPlayerPrefs = PlayerPrefs.GetInt("SoundOn", 1);

        if (canVibratePlayerPrefs == 1)
        {
            canVibrate = true;
            toggleImage.gameObject.SetActive(false);
        }
        else if (canVibratePlayerPrefs == 0)
        {
            canVibrate = false;
            toggleImage.gameObject.SetActive(true);
        }

        if (soundOnPlayerPrefs == 1)
        {
            soundOn = true;
            AudioListener.pause = false;
            soundToggleImage.gameObject.SetActive(false);

        }
        else if (soundOnPlayerPrefs == 0)
        {
            soundOn = false;
            AudioListener.pause = true;
            soundToggleImage.gameObject.SetActive(true);
        }

        for (int i = 0; i < other.Count; i++)
        {
            _rb[i] = other[i].gameObject.GetComponent<Rigidbody>();
        }

    }

    // Update is called once per frame
    public void Toggle()
    {
        if (canVibrate)
        {
            canVibrate = false;
            toggleImage.gameObject.SetActive(true);
            PlayerPrefs.SetInt("CanVibrate", canVibrate ? 1 : 0);
        }
        else if (!canVibrate)
        {
            canVibrate = true;
            toggleImage.gameObject.SetActive(false);
            PlayerPrefs.SetInt("CanVibrate", canVibrate ? 1 : 0);
        }
    }

    public void ToggleMusic()
    {
        if (soundOn)
        {
            if (!gameMusic.audioSource.isPlaying)
            {
                gameMusic.audioSource.Play();
            }
            else
            {
                gameMusic.audioSource.Stop();
            }
            AudioListener.pause = true;
            soundOn = false;
            soundToggleImage.gameObject.SetActive(true);
            PlayerPrefs.SetInt("SoundOn", soundOn ? 1 : 0);
        }
        else if (!soundOn)
        {
            if (!gameMusic.audioSource.isPlaying)
            {
                gameMusic.audioSource.Play();
            }
            else
            {
                gameMusic.audioSource.Stop();
            }
            AudioListener.pause = false;
            soundOn = true;
            soundToggleImage.gameObject.SetActive(false);
            PlayerPrefs.SetInt("SoundOn", soundOn ? 1 : 0);
        }
    }
    void Update()
    {
        for (int j = 0; j < other.Count; j++)
        {
            dist[j] = Vector3.Distance(other[j].position, transform.position);
            if (dist[j] < 4)
            {
                for (int k = 0; k < other.Count; k++)
                {
                    dir[k] = (other[k].position - transform.position).normalized;
                    animalSound = other[k].gameObject.GetComponent<AudioSource>();
                    animalSound.Play();
                    _rb[j].AddForce(dir[j] * pushForce, ForceMode.Impulse);
                    if (canVibrate)
                    {
                        Handheld.Vibrate();
                    }
                }
            }
        }
    }
}

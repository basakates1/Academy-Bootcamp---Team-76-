using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public bool canVibrate;
    private int canVibratePlayerPrefs;
    public float pushForce = 1.5f;
    //public Transform facing;
    public List<Transform> other = new List<Transform>();
    [SerializeField] List<Rigidbody> _rb = new List<Rigidbody>();

    [SerializeField] List<float> dist = new List<float>();
    public List<Vector3> dir = new List<Vector3>();
    private AudioSource animalSound;

    public Image toggleImage;
    void Start()
    {
        canVibratePlayerPrefs = PlayerPrefs.GetInt("CanVibrate", 1);

        if (canVibratePlayerPrefs == 1)
        {
            canVibrate = true;
            //vibToggle.isOn = false;
            toggleImage.gameObject.SetActive(false);
        }
        else if (canVibratePlayerPrefs == 0)
        {
            canVibrate = false;
            //vibToggle.isOn = true;
            toggleImage.gameObject.SetActive(true);
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
            //vibToggle.isOn = true;
            toggleImage.gameObject.SetActive(true);
            PlayerPrefs.SetInt("CanVibrate", canVibrate ? 1 : 0);
        }
        else if (!canVibrate)
        {
            canVibrate = true;
            //vibToggle.isOn = false;
            toggleImage.gameObject.SetActive(false);
            PlayerPrefs.SetInt("CanVibrate", canVibrate ? 1 : 0);
        }
    }
    void Update()
    {
        for (int j = 0; j < other.Count; j++)
        {
            dist[j] = Vector3.Distance(other[j].position, transform.position);
            if (dist[j] < 3)
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

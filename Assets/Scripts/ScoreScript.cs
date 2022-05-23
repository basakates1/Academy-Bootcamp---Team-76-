using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public Text animalScore;
    public int animalNeeded;
    private int animalCounter = 0;
    public GameObject winPanel;

    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private ParticleSystem _confetti;
    [SerializeField] private ParticleSystem _trails;


    void Start()
    {
        winPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        animalScore.text = animalCounter + " / " + animalNeeded;
        if (animalCounter == animalNeeded)
        {
            winPanel.SetActive(true);
            _playerAnimator.SetBool("canDance", true);
            _confetti.Play();
            _trails.Play();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            animalCounter++;
        }
    }
}

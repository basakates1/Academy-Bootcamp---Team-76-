using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreScript : MonoBehaviour
{
    public Text animalScore;
    public Text countdownText;
    public TMP_Text coinGainedText;
    public int animalNeeded;
    private int animalCounter = 0;
    public int totalCoin;
    public int coinGained = 0;
    public float countdownTimer = 10.0f;
    public GameObject winPanel;
    public GameObject losePanel;
    public int animalPresent;

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
        countdownText.text =((int)(countdownTimer-Time.timeSinceLevelLoad)).ToString();
        animalPresent= GameObject.FindGameObjectsWithTag("Animal").Length;
        
        if(animalPresent<animalNeeded){
            countdownText.gameObject.SetActive(false);
            losePanel.SetActive(true);
        }
        

        if (animalCounter == animalNeeded && countdownTimer>=Time.timeSinceLevelLoad)
        {
            countdownText.gameObject.SetActive(false);
            winPanel.SetActive(true);
            _playerAnimator.SetBool("canDance", true);
            _confetti.Play();
            _trails.Play();
        }
        else if(animalCounter<animalNeeded&&countdownTimer<=Time.timeSinceLevelLoad){
            //countdownText.text="0";
            countdownText.gameObject.SetActive(false);
            losePanel.SetActive(true);
            _playerAnimator.SetBool("isDefeated", true);
        }

        coinGained=animalCounter*5;
        coinGainedText.text=coinGained.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            animalCounter++;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public float duration=5f;
    public float multiplier=1.5f;
    [SerializeField] GameObject powerupParticle;
    [SerializeField] GameObject powerupMesh;
    [SerializeField] ParticleSystem poofParticle;
    private bool playerCollided;


    private void Start() {
        playerCollided =false;
    }


    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player"))
        {
            if (!playerCollided)
            {
                playerCollided=true;
                StartCoroutine(Pickup(other));
            }
            
            
        }
        
    }


    IEnumerator Pickup(Collider player){

        PlayerJoystickController playerController = player.gameObject.GetComponent<PlayerJoystickController>();
        
        playerController.speed*=multiplier;

        powerupParticle.SetActive(false);
        powerupMesh.SetActive(false);
        poofParticle.Play();
        yield return new WaitForSeconds(duration);

        playerController.speed/=multiplier;
        Destroy(gameObject);
    }
}

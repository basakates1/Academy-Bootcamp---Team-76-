using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalFinishLine : MonoBehaviour
{
    private bool isTriggered = false;
    public Transform toplanmaNoktasi;
    public float speed = 1.0f;
    private Material originalMat;
    public Material redMat;
    public float flashTimer=0.2f;
    private Animator animalAnim;
    

    private void Start() {
        originalMat=gameObject.GetComponent<MeshRenderer>().material;
        animalAnim=gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (isTriggered)
        {
            transform.LookAt(toplanmaNoktasi);
            transform.position = Vector3.MoveTowards(transform.position, toplanmaNoktasi.position, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FinishLine")
        {
            isTriggered = true;
        }
        if (other.tag == "ToplanmaNoktasi")
        {
            animalAnim.SetBool("isDead",true);
            //gameObject.SetActive(false);
        }
        if(other.tag == "Trap"){
            StartCoroutine(FlashMat());
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag=="Wolf"||other.gameObject.tag=="Cactus")
        {
            StartCoroutine(FlashMat());
        }
    }

    public IEnumerator FlashMat(){
        gameObject.GetComponent<MeshRenderer>().material=redMat;
        yield return new WaitForSeconds(flashTimer);
        gameObject.GetComponent<MeshRenderer>().material=originalMat;
        gameObject.SetActive(false);

    }

}

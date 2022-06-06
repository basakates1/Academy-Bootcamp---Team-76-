using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript : MonoBehaviour
{
    private Animator _wolfAnim;
    public GameObject[] animals;
    public GameObject selectedAnimal;
    public float speed=1.0f;
    public Transform wolfSpawn;
    public bool didEatAnimal=false;

    private int wolfCounter;


    private void Start() {
        
        _wolfAnim = gameObject.GetComponent<Animator>();
        animals= GameObject.FindGameObjectsWithTag("Animal");
        selectedAnimal = animals[Random.Range(0,animals.Length)];

    }

   private void OnMouseDown() {
       wolfCounter++;
   }

private void Update() {

    if (wolfCounter>=3||didEatAnimal)
    {
        transform.LookAt(wolfSpawn);
        transform.position = Vector3.MoveTowards(transform.position, wolfSpawn.position, speed * Time.deltaTime);
    }
    else if(selectedAnimal.activeInHierarchy&&wolfCounter<3){
        transform.LookAt(selectedAnimal.transform);
        transform.position = Vector3.MoveTowards(transform.position, selectedAnimal.transform.position, speed * Time.deltaTime);
    }
    }
    



    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag=="Animal")
        {
            didEatAnimal=true;
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="WolfSpawn")
        {
            gameObject.SetActive(false);
        }
    }

}

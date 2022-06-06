using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusCollision : MonoBehaviour
{
    public AnimalFinishLine animalFinishLine;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Animal"){
            StartCoroutine(animalFinishLine.FlashMat());

        }
    }
}

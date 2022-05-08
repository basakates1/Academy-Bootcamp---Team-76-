using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public List<Transform> other = new List<Transform>();
    [SerializeField] List<Rigidbody> _rb = new List<Rigidbody>();

    [SerializeField] List<float> dist = new List<float>();
    public List<Vector3> dir = new List<Vector3>();
    void Start()
    {
        for (int i = 0; i < other.Count; i++)
        {
            _rb[i] = other[i].gameObject.GetComponent<Rigidbody>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int j = 0; j < other.Count; j++)
        {
            dist[j] = Vector3.Distance(other[j].position, transform.position);
            if (dist[j] < 3)
            {
                for (int k = 0; k < other.Count; k++)
                {
                    dir[k] = (other[k].position - transform.position);
                    _rb[j].AddForce(dir[j], ForceMode.Impulse);
                }



            }
        }




    }
}

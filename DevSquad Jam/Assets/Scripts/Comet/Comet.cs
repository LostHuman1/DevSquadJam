using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    [SerializeField] AudioSource cometMovement;
    public Transform start;
    public Transform end;
    [SerializeField] float speed = 1;
    Vector3 direction;


    void Start()
    {
        direction = end.position - start.position;
        StartCoroutine("Destruction");
        cometMovement.Play();
    }

    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);
        transform.Rotate(0, Time.deltaTime * speed, 0);
    }
}

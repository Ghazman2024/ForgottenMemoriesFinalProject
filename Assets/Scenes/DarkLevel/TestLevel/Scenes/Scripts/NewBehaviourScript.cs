using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int walkspeed =1;
    private void Update()
    {


        transform.Translate(Vector3.forward * Time.deltaTime * walkspeed); }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("attack")){
            GetComponent<Animator>().SetBool("zombieattack", true);
            GetComponent<Animator>().SetBool("zombiewalk", false);

        }

    }

}




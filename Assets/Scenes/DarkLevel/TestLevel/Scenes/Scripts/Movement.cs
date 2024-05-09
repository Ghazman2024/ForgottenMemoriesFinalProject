using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float runspeed = 4.5f;
    float idletime = 7f;
    float timer = 0;
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("Run", true);
            GetComponent<Animator>().SetBool("Idle", false);
            
            transform.Translate(Vector3.forward * Time.deltaTime * runspeed);

        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("Run", true);
            GetComponent<Animator>().SetBool("Idle", false);
           transform.Translate(Vector3.back * Time.deltaTime * runspeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            { GetComponent<Animator>().SetTrigger("Die"); }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        { GetComponent<Animator>().SetTrigger("Punch"); }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            GetComponent<Animator>().SetBool("Guard", true);
            GetComponent<Animator>().SetBool("Idle", false);
        }
        if (Input.anyKey)
        {
            timer = 0f;
        }

        if (!Input.anyKey)
        {
            timer += Time.deltaTime;
            GetComponent<Animator>().SetBool("Run", false);
            GetComponent<Animator>().SetBool("Idle", true);
            GetComponent<Animator>().SetBool("Guard", false);
        }
        if(timer>=idletime) { GetComponent<Animator>().SetTrigger("emote"); }
    }

}

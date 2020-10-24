using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject npc;

    public Animator door1 = null;
    public Animator door2 = null;

    public bool openDoor1 = false;
    public bool openDoor2 = false;

    public void Start()
    {

        StartCoroutine(WaitNpc());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door1.Play("DoorOpen", 0, 0.0f);
            door2.Play("DoorOpen2", 0, 0.0f); 
            gameObject.SetActive(false);

            //if (openDoor1)
            //{
            //    door1.Play("DoorOpen", 0, 0.0f);
            //    gameObject.SetActive(false);
            //}
            //else if (openDoor2)
            //{

            //    door2.Play("DoorOpen2", 0, 0.0f);
            //    gameObject.SetActive(false);
            //}
        }
        if(other.tag == "Player")
        {
            npc.SetActive(true);
            Debug.Log("NPC started");
        }

    }
    IEnumerator WaitNpc()
    {
        yield return new WaitForSeconds(2);
    }
}

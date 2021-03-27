using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOrb : MonoBehaviour
{
    public KeyCode moveL;
    public KeyCode moveR;

    public float horizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";

    public Transform BoomObj;

    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, 0, 4);

        if (Input.GetKeyDown(moveL) && (laneNum > 1) && (controlLocked == "n")) 
        {

            horizVel = -2;

            StartCoroutine(stopSlide());

            laneNum -= 1;

            controlLocked = "y";
        }

        if (Input.GetKeyDown(moveR) && (laneNum < 3) && (controlLocked == "n"))
        {

            horizVel = 2;

            StartCoroutine(stopSlide());

            laneNum += 1;

            controlLocked = "y";
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //Moved this to ontriggerenter
        /*if (other.gameObject.tag == "Lethal")
        {
            Destroy(gameObject);
        }
        */
        
    }

    void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.name == "RampTriggerB")
        {
            GM.vertVel = 2;
        }

        if (other.gameObject.name == "RampTriggerT")
        {
            GM.vertVel = 0;
        }
        */
        if (other.gameObject.name == "Health")
        {
            Destroy(other.gameObject);
        }

        if(other.gameObject.name == "Exit")
        {
            GM.lvlCompStatus = "Success!";
            SceneManager.LoadScene("LevelComp");
        }

        if (other.gameObject.tag == "Lethal")
        {
            Destroy(gameObject);
            GM.ZVelAdj = 0;
            Instantiate(BoomObj, transform.position, BoomObj.rotation);
            GM.lvlCompStatus = "Fail";
        }

        if (other.gameObject.name == "Coin")
        {
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horizVel = 0;
        controlLocked = "n";
    }
}

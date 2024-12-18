using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//This, along with all enemies, will go completely unused because using this caused unity to crash. not enough time to find out why.
public class Enemy1 : MonoBehaviour{
    public Vector3 Location1;
    public Vector3 Location2;
    bool check;
    public Vector3 IWannaBeHereYo;
    public Vector3 newhome;
    // Start is called before the first frame update
    void Start()
    {
        born(Location1, Location2);
    }

    // Update is called once per frame
    void Update()
    {
        if (check == false)
        {
            IWannaBeHereYo = Location2;
        }
        if (check == true)
        {

            IWannaBeHereYo = Location1;
        }
        while (transform.position != IWannaBeHereYo){
            if (transform.position.x < IWannaBeHereYo.x){
                newhome = new Vector3(transform.position.x + .1f, GetComponent<Rigidbody>().transform.position.y, 0f);
            }
            if (transform.position.x > IWannaBeHereYo.x){
                newhome = new Vector3(transform.position.x - .1f, GetComponent<Rigidbody>().transform.position.y, 0f);
            }
            transform.position = newhome;
            if (transform.position.y < IWannaBeHereYo.y)
            {
                newhome = new Vector3(GetComponent<Rigidbody>().transform.position.x, transform.position.y + .1f, 0f);
            }
            if (transform.position.y > IWannaBeHereYo.y)
            {
                newhome = new Vector3(GetComponent<Rigidbody>().transform.position.x, transform.position.y - .1f, 0f);
            }
        }
        if (check == false)
        {
            check = true;
        }
        if (check == true && IWannaBeHereYo== Location2)
        {

            check = false;
        }
    }

    void born(Vector3 l1, Vector3 l2)
    {
        transform.position = l1;
        Location1 = l1;
        Location2 = l2;
    }
    void WrapAround(float baby)
    {
        {
            if (baby > 16)
            {
                newhome = new Vector3(-15.99f, GetComponent<Rigidbody>().transform.position.y, 0f);
            }
            if (baby < -16)
            {
                newhome = new Vector3(15.99f, GetComponent<Rigidbody>().transform.position.y, 0f);
            }
            transform.position = newhome;
        }
    }
}

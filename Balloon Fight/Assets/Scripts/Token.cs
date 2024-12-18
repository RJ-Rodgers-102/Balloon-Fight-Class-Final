using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public int spin;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        spin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //rotation. Janky but I couldn't figure anything better out
        if (spin == 360){
            spin = 0;
        }
        spin = spin + 1;
        Quaternion twirl = new Quaternion(0, spin, 0, 50);
        transform.rotation = twirl;
    }
}

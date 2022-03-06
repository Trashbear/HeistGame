using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_BombExpand : MonoBehaviour
{
    public GameObject smokeObj;

    public Transform bombObj;

    private int smokeUsed = 1;

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "floor" && smokeUsed > 0)
        {
            Instantiate(smokeObj, bombObj.position, bombObj.rotation);
            smokeObj.transform.localScale = new Vector3(15f, 15f, 15f);
            smokeUsed -= 1;
            Destroy(this.gameObject, 5);
            //Destroy(smokeObj.gameObject, 5);

            //can't get the smoke object to disappear, though
        }
    }
}

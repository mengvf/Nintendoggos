using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eating : MonoBehaviour
{
     void OnCollisionEnter (Collision col)
    {
		Debug.Log(col.collider.name);
        if(col.gameObject.tag == "collision")
        {
			Debug.Log("We hit something");
            Destroy(col.gameObject);
        }
    }
}

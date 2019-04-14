using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eating : MonoBehaviour
{
	 Animator dogAnim;
     void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.name == "Steak_Uncooked")
        {
            Destroy(col.gameObject);
        }
    }
}

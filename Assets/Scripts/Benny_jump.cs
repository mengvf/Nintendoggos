using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benny_jump : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "cool_cube")
		{
			Destroy(col.gameObject);
		}
	}
}

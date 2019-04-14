using UnityEngine;

public class follow_benny : MonoBehaviour
{
    public Transform benny;
	public Vector3 offset;
	
    void Update()
    {
		transform.position = benny.position + offset;
        
    }
}

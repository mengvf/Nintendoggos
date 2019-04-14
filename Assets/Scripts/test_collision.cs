using UnityEngine;

public class test_collision : MonoBehaviour
{
    public Rigidbody rb;
	public float forwardForce = 2000f;
	public float sidewaysForce = 500f;
	
	void FixedUpdate ()
	{
		rb.AddForce(0, 0, 2000 * Time.deltaTime);
		
		if ( Input.GetKey("d"))
		{
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey("a"))
		{
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
		}
	}
}

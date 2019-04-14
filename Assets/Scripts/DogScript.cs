using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    AudioClip voice_command;
    public GameObject main_camera;
    Animator dogAnim;
    Rigidbody rb;
    bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        dogAnim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t") == true)
        {
            int min;
            int max;
            Microphone.GetDeviceCaps(Microphone.devices[0], out min, out max);
            voice_command = Microphone.Start(Microphone.devices[0], false, 2, min);
        }
        if (Input.GetKeyUp("t") == true)
        {
            Microphone.End(Microphone.devices[0]);
            //Voice has been detected. Move dog towards camera
            this.transform.LookAt(new Vector3(main_camera.transform.position.x, this.transform.position.y, main_camera.transform.position.z), new Vector3(0, 1, 0));
            this.transform.Rotate(0, 90, 0);
            running = true;
            rb.AddRelativeForce(new Vector3(0, 0, -100));
        }
        if (running)
        {
            dogAnim.Play(Animator.StringToHash("Base Layer.run"), 0);
        }
        if (Input.GetKeyDown("s"))
        {
            StopDog();
            rb.AddRelativeForce(new Vector3(0, 0, 100));
        }
    }

    void StopDog()
    {
        running = false;
        this.transform.LookAt(new Vector3(main_camera.transform.position.x, this.transform.position.y, main_camera.transform.position.z), new Vector3(0, 1, 0));
        dogAnim.Play(Animator.StringToHash("Base Layer.Empty"));
    }
}

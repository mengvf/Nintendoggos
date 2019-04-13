using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRecording : MonoBehaviour
{
    AudioClip voice_command;
    public GameObject dog;
    public GameObject main_camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t") == true)
        {
            int min;
            int max;
            Microphone.GetDeviceCaps(Microphone.devices[0], out min, out max);
            print(min);
            print(max);
            voice_command = Microphone.Start(Microphone.devices[0], false, 2, min);
        }
        if (Input.GetKeyUp("t") == true)
        {
            Microphone.End(Microphone.devices[0]);
            //Voice has been detected. Move dog towards camera
            dog.transform.LookAt(new Vector3(main_camera.transform.position.x, dog.transform.position.y, main_camera.transform.position.z), new Vector3(0, 1, 0));
            dog.GetComponent<Animator>().Play("attack");
        }
    }
}

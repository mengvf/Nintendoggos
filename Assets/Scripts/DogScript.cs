using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using UnityEngine.Windows.Speech;

public class DogScript : MonoBehaviour
{
    AudioClip voice_command;
    public GameObject main_camera;
    Animator dogAnim;
    Rigidbody rb;
    bool running = false;
    bool sitting = false;
    public float distance_to_stopping_before_camera = 7;

    Gyroscope m_Gyro;

    //Speech
    //private KeywordRecognizer keywordRecognizer;
    //private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        dogAnim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();

        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;

        //Speech
        //actions.Add("ben", RunTowardsCamera);

        /*keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizeSpeech;
        keywordRecognizer.Start();*/
    }

    /*private void RecognizeSpeech(PhraseRecognizedEventArgs speech)
    {
        actions[speech.text].Invoke();
    }*/

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            dogAnim.Play(Animator.StringToHash("Base Layer.run"), 0);
        }
        if (sitting)
        {
            dogAnim.Play(Animator.StringToHash("Base Layer.idle"), 0);
        }
        if (Input.GetKeyDown("s"))
        {
            StopDog();
        }
        //Stop dog when it's close to the camera
        if (Vector3.Distance(this.transform.position, main_camera.transform.position) < distance_to_stopping_before_camera && running)
        {
            StopDog();
        }
        //print(m_Gyro.rotationRate);
        print(m_Gyro.attitude.eulerAngles);
        if (m_Gyro.attitude.eulerAngles.z >= 120 && running == false || Input.GetKeyDown("w"))
        {
            RunTowardsCamera();
        }
    }

    void OnGUI()
    {
        //Output the rotation rate, attitude and the enabled state of the gyroscope as a Label
        GUI.Label(new Rect(500, 300, 200, 40), "Gyro rotation rate " + m_Gyro.rotationRate);
        GUI.Label(new Rect(500, 350, 200, 40), "Gyro attitude" + m_Gyro.attitude);
        GUI.Label(new Rect(500, 400, 200, 40), "Gyro enabled : " + m_Gyro.enabled);
    }

    void RunTowardsCamera()
    {
        if (Vector3.Distance(this.transform.position, main_camera.transform.position) > distance_to_stopping_before_camera)
        {
            rb.AddForce((new Vector3(main_camera.transform.position.x, this.transform.position.y, main_camera.transform.position.z) - this.transform.position).normalized * 100);
            running = true;
            //Voice has been detected. Move dog towards camera
            this.transform.LookAt(new Vector3(main_camera.transform.position.x, this.transform.position.y, main_camera.transform.position.z), new Vector3(0, 1, 0));
            this.transform.Rotate(0, 90, 0);
            sitting = false;
        }
    }

    void StopDog()
    {
        running = false;
        rb.velocity = new Vector3(0, 0, 0);
        //this.transform.LookAt(new Vector3(main_camera.transform.position.x, this.transform.position.y, main_camera.transform.position.z), new Vector3(0, 1, 0));
        sitting = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [SerializeField]
    private bool shakeOn = false;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private Animator camAni;
    [SerializeField]
    private float shakeMag, shakeSpeed;
    private Vector3 camOGPos;
    [SerializeField]
    private float shakeDuration, decreaseFactor;
    public UnityEvent shakeEvent;
    [SerializeField]
    private int waitFrames;
    [SerializeField]
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeOn) 
        {
            if (shakeDuration > 0)
            {
                if (i == waitFrames)
                {
                    shakeCam();
                    i = 0;
                }
                else 
                {
                    i++;
                }
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else 
            {
                shakeDuration = 0;
                cam.transform.position = camOGPos;
                camAni.SetBool("F2Trigger", true);
            }
        }
    }

    void shakeCam() 
    {
        cam.transform.position = camOGPos + Random.insideUnitSphere * shakeMag;
        //Vector3.MoveTowards(cam.transform.position, camOGPos + Random.insideUnitSphere * shakeMag, shakeSpeed);
        //Vector3.Lerp(camOGPos, camOGPos + Random.insideUnitSphere * shakeMag, shakeSpeed);
    }

    public void shakeFuncOn() 
    {
        camOGPos = cam.transform.position;
        shakeOn = true;
    }

    public void invokeShakeEvent() 
    {
        shakeEvent.Invoke();
    }
}

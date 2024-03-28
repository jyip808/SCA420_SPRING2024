using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    public UnityEvent loadScene;
    [SerializeField]
    private int waitFrames;
    [SerializeField]
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        camOGPos = cam.transform.position;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 24;
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
                //camAni.SetBool("F2Trigger", true);
                StartCoroutine(waitForShake());
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
        shakeOn = true;
    }

    public void invokeShakeEvent() 
    {
        shakeEvent.Invoke();
    }

    public void invokeloadSceneEvent()
    {
        loadScene.Invoke();
    }

    public void loadSceneNum(int num) 
    {
        SceneManager.LoadScene(num);
    }

    private IEnumerator waitForShake() 
    {
        yield return new WaitForSeconds(shakeDuration);
        //camAni.enabled = true;
    }
}

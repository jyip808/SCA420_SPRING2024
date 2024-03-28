using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationAt : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    //[SerializeField]
    //private float endframe;
    [SerializeField]
    private float startTime;
    [SerializeField]
    private string animName;
    [SerializeField]
    private AnimationClip clip;

    // Start is called before the first frame update
    void Start()
    {
        float temp = startTime/clip.length;
        if (anim != null) 
        {
            anim.Play(animName, 0, temp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

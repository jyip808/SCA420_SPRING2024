using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationAt : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float endframe;
    [SerializeField]
    private float startframe;
    [SerializeField]
    private string animName;

    // Start is called before the first frame update
    void Start()
    {
        float temp = startframe/endframe;
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

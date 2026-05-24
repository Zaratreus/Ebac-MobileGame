using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationExample : MonoBehaviour
{
    public Animation animation;

    public AnimationClip Run;
    public AnimationClip Idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            PlayAnimation(Run);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            PlayAnimation(Idle);
        }
    }

    private void PlayAnimation(AnimationClip c)
    {
        //animation.clip = c;
        animation.CrossFade(c.name);
    }

}

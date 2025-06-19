using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDetector : MonoBehaviour
{
    public List<string> names;
    private void Update()
    {
        for(int i = 0; i < names.Count; i++)
        {
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(names[i]))
            {
                //Debug.Log(GetComponent<Animator>().runtimeAnimatorController.animationClips[0].name);
            }
        }
        
    }
}

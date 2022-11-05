using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSequence : MonoBehaviour
{
    [SerializeField]
    private Animator myAnim;
    private bool animated = false;

    public AudioSource music;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !animated)
        {
            myAnim.SetBool("PlayBounce", true);
            music.Play();
            animated = true;
        }
    }
}

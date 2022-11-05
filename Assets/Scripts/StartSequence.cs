using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSequence : MonoBehaviour
{
    [SerializeField]
    private Animator myKickAnim;
    [SerializeField]
    private Animator myBassAnim;
    private bool animated = false;

    public AudioSource music;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !animated)
        {
            myKickAnim.SetBool("PlayBounce", true);
            myBassAnim.SetBool("PlayBass", true);
            music.Play();
            animated = true;
        }
    }
}

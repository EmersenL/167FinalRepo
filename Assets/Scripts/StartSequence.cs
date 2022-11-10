using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSequence : MonoBehaviour
{
    [SerializeField]
    private Animator myLead;
    [SerializeField]
    private Animator mySnareAnim;
    [SerializeField]
    private Animator myKickAnim;
    public GameObject bassPrefab;
    // private ArrayList bassStuff;
    private bool animated = false;

    public AudioSource music;

    // for storing the animation states
    delegate void AnimsChange();
    List<AnimsChange> changeAnims = new List<AnimsChange>();
    int counter = 0;

    //adding functions to animation states
    private void Start()
    {
        changeAnims.Add(AnimsOn);
        // changeAnims.Add(AnimsOff);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && !animated)
    //    {
    //        changeAnims[counter]();
    //        // if (counter > 1) counter = 0;
    //    }
    //}

    public void StartAnims()
    {
        if (!animated) changeAnims[counter]();
    }

    IEnumerator BassCoroutine()
    {
        // GameObject temp;
        for (int i = 0; i < 4; i++)
        {
            Instantiate(bassPrefab, new Vector3(-2.09f, 9.477f, -7.93f), bassPrefab.transform.rotation);
            yield return new WaitForSeconds(0.25f);
            // if (i == 3) animated = false;
        }
    }

    void ChangeMusic(bool anim)
    {
        if (anim == true) music.Play();
        else music.Stop();
    }

    void AnimsOn()
    {
        myLead.SetBool("PlayLead", true);
        mySnareAnim.SetBool("PlaySnare", true);
        myKickAnim.SetBool("PlayBounce", true);
        StartCoroutine(BassCoroutine());
        animated = true;
        ChangeMusic(animated);
    }

    //void AnimsOff()
    //{
    //    myLead.SetBool("PlayLead", false);
    //    mySnareAnim.SetBool("PlaySnare", false);
    //    myKickAnim.SetBool("PlayBounce", false);
    //    for (int i = 0; i < 4; i++)
    //    {
    //        // Destroy((GameObject)bassStuff[i]);
    //    }
    //    animated = false;
    //    ChangeMusic(animated);
    //}
}

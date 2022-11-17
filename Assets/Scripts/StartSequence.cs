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

    //lights
    [SerializeField]
    private Animator myLight;

    public AudioSource music;

    // for storing the animation states
    delegate void AnimsChange();
    List<AnimsChange> changeAnims = new List<AnimsChange>();
    int counter = 0;

    //For deleting the bass
    //public GameObject ForBass;
    //public Transform Parent;
    public float fabNum = 0;

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
            fabNum += 0.25f;
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
        StartCoroutine(AnimationCoroutine());
        animated = true;
        ChangeMusic(animated);
    }

    IEnumerator AnimationCoroutine()
    {
        myKickAnim.SetBool("PlayBounce", true);
        // GameObject temp;
        yield return new WaitForSeconds(8.0f);
        StartCoroutine(BassCoroutine());
        yield return new WaitForSeconds(8.0f);
        mySnareAnim.SetBool("PlaySnare", true);
        yield return new WaitForSeconds(16.0f);
        myLead.SetBool("PlayLead", true);
        myLight.SetBool("PlayLights", true);
        yield return new WaitForSeconds(32.0f);
        mySnareAnim.SetBool("PlaySnare", false);
        yield return new WaitForSeconds(23.5f);
        myKickAnim.SetBool("PlayBounce", false);
        yield return new WaitForSeconds(8.0f);
        myLead.SetBool("PlayLead", false);
        //Destroy(ForBass);
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

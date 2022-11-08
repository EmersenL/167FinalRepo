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
    private bool animated = false;

    public AudioSource music;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !animated)
        {
            myLead.SetBool("PlayLead", true);
            mySnareAnim.SetBool("PlaySnare", true);
            myKickAnim.SetBool("PlayBounce", true);
            StartCoroutine(BassCoroutine());
            animated = true;
            StartMusic(animated);
        }
    }

    IEnumerator BassCoroutine()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(bassPrefab, new Vector3(-2.09f, 9.477f, -7.93f), bassPrefab.transform.rotation);
            yield return new WaitForSeconds(0.25f);
        }
    }

    void StartMusic(bool anim)
    {
        if (anim == true) music.Play();
    }
}

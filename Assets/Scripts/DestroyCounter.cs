using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCounter : MonoBehaviour
{
    public StartSequence startSeqScript;
    private float bassNum;

    // Start is called before the first frame update
    void Start()
    {
        startSeqScript = GameObject.Find("Manager").GetComponent<StartSequence>();
        bassNum = startSeqScript.fabNum;
        StartCoroutine(BassSelfDestruct());
    }

    IEnumerator BassSelfDestruct()
    {
        yield return new WaitForSeconds(72.4f - bassNum);
        Destroy(this.gameObject);
    }
}

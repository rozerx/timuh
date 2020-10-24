using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] route;

    private int routeToGo;

    private float tParam;

    private Vector3 npcPosition;

    private float speedModifier;

    private bool coroutineAllowed;

    void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        speedModifier = 0.1f;
        coroutineAllowed = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
            StartCoroutine(GoByRoute(routeToGo));
    }

    private IEnumerator GoByRoute(int routeNum)
    {
        coroutineAllowed = false;

        Vector3 p0 = route[routeNum].GetChild(0).position;
        Vector3 p1 = route[routeNum].GetChild(1).position;
        Vector3 p2 = route[routeNum].GetChild(2).position;
        Vector3 p3 = route[routeNum].GetChild(3).position;

        while (tParam < 1)
        {
            //npcPosition = 

            tParam += Time.deltaTime * speedModifier;

            npcPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * p1 +
                3 * (1 - tParam) * Mathf.Pow(1 - tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;
            transform.position = npcPosition;
            yield return new WaitForEndOfFrame();
        }
        //tParam = 0f;
        //routeToGo += 1;
        //if (routeToGo > route.Length - 1)
        //    routeToGo = 0;
        //coroutineAllowed = true;
    }
}

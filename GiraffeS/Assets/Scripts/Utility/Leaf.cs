using System.Collections;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    bool shaking = false;
    public CollisionLogic giraffe;
    [SerializeField]
    float shakeAmount;
    [SerializeField]
    float stefansPenisSize;

    [SerializeField]
    bool top = false;
    [SerializeField]
    bool right = false;
    [SerializeField]
    bool left = false;
    [SerializeField]
    bool bot = false;

    Vector3 originalPosition;
    bool coRunning = false;
    bool seCoRunning = false;

    private void Update()
    {
        if (coRunning)
        {
            Vector3 newpos = Random.insideUnitSphere * (Time.deltaTime * shakeAmount);
            newpos += transform.position;
            newpos.z = transform.position.z;

            if (bot)
                newpos.x = transform.position.x;
            else if (left)
                newpos.y = transform.position.y;
            else if(right)
                newpos.y = transform.position.y;
            else if(top)
                newpos.x = transform.position.x;



            transform.position = newpos;
        }
    }

    public void GetInThere()
    {
        if (seCoRunning)
            transform.localPosition = originalPosition;
        if ((!coRunning && !giraffe.IsInBush) || (!coRunning && !giraffe.IsInSpikes))
            StartCoroutine("ShakyShakyTime");
    }

    IEnumerator ShakyShakyTime()
    {
        coRunning = true;
        originalPosition = transform.localPosition;
        StopCoroutine("ToPlace");

        if (bot)
            StartCoroutine("ToPlace", transform.localPosition + new Vector3(0, stefansPenisSize));
        else if (left)
            StartCoroutine("ToPlace", transform.localPosition + new Vector3(stefansPenisSize, 0));
        else if (right)
            StartCoroutine("ToPlace", transform.localPosition + new Vector3(-stefansPenisSize, 0));
        else if (top)
            StartCoroutine("ToPlace", transform.localPosition + new Vector3(0, -stefansPenisSize));

        if (shaking == false)
            shaking = true;

        if (transform.parent.name.Contains("Spikes"))
            yield return new WaitUntil(() => !giraffe.IsInSpikes);
        if (transform.parent.name.Contains("Leaves"))
            yield return new WaitUntil(() => !giraffe.IsInBush);
        StopCoroutine("ToPlace");
        StartCoroutine("ToPlace", originalPosition);

        //transform.localPosition = originalPosition;
        shaking = false;
        coRunning = false;
    }

    IEnumerator ToPlace(Vector3 desiredPosition)
    {
        seCoRunning = true;
        while (true)
        {
            Vector3 nextPosition = Vector3.Lerp(transform.localPosition, desiredPosition, 0.125f);
            transform.localPosition = nextPosition;
            yield return null;
            if (Vector3.Distance(transform.localPosition, desiredPosition) < 0.5)
            {
                transform.localPosition = desiredPosition;
                seCoRunning = false;
                break;
            }
        }
    }
}

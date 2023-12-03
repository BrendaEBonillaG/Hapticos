using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public KidMovement kidMovement;

    //void Start()
    //{
    //    //kidMovement.EnableZ(true);
    //   // StartCoroutine(tiempo());
    //   // StartCoroutine(EnableZAfterDelay(5.0f));
    //}

    //IEnumerator EnableZAfterDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    kidMovement.EnableZ(true);
    //}
    IEnumerator tiempo()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            //if (power < 100)
            //{
            //    power += 0.5f;
            //}
        }
    }
}

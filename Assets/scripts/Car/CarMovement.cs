using System.Collections;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CarMoveOrder());
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0.1f, 0));
    }

    IEnumerator CarMoveOrder()
    {
        yield return new WaitForSeconds(2);

        Quaternion startRotation = Quaternion.Euler(-90, 0, -90);
        Quaternion endRotation = Quaternion.Euler(-90, 90, -90);

        float duration = 5.0f;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration; 
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            elapsed += Time.deltaTime; 
            yield return null; 
        }

        transform.rotation = endRotation;
    }
}
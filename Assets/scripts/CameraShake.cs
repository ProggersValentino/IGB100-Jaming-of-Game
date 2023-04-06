using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 5f;

    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    // public function that will play the camera shake 
    public void Play(){
        StartCoroutine(shake());
    }

    // Enum for camera shake 
    IEnumerator shake(){
        float elapseTime = 0f;

        //loops until elapse time is = to shake duration 
        while(elapseTime < shakeDuration){
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude; //randomly sets a position within the circle radius 
            elapseTime += Time.deltaTime; //to prevent from getting stuck in an infinite loop 
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition; //restarts the position of the camera back to the initial position

    }


}

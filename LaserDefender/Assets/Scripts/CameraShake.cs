using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //thoi` luong. rung
    [SerializeField] float shakeDuration = 1f;
    //cuong` do. rung
    [SerializeField] float shakeMagnitude = 0.5f;
    //vi. tri' ban dau` cua? camera, sau khi rung thi` cho camera tro ve vi tri' ban dau`
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void Play()
    {
        StartCoroutine(Shake());
    }
    
    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while(elapsedTime < shakeDuration)
        {
            //Random.insideUnitCircle la 1 vecto2 them (Vector3) se~ ep kieu cua? no thanh` 1 Vector3
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
       
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShacke : MonoBehaviour
{
    public static CameraShacke instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    

    
    public IEnumerator shack (float duration , float magnitude)
    {
        Vector3 OriginalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed< duration)
        {
            float x = Random.Range(-0.1f,0.1f) * magnitude;
            float y = Random.Range(-0.1f, 0.1f) * magnitude;

            transform.position = new Vector3(x, y,OriginalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = OriginalPos;
    }
    void Start()
    {
        
    }

   
    void Update()
    {
       
    }
}

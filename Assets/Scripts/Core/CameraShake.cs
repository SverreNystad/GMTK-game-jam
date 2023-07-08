using System.Collections;
using UnityEngine;

namespace Camera
{
    public class CameraShake : MonoBehaviour
    {
        public IEnumerable Shake(float duration, float magnitude) 
        {
            Vector3 orginalPos = transform.localPosition;
            float timeElapsed = 0.0f;

            while (timeElapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, orginalPos.z);

                timeElapsed += Time.deltaTime;
                
                yield return null;
            }

            transform.localPosition = orginalPos;
        }
    }
}
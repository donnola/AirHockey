using UnityEngine;

namespace Main
{
    public class WasherController : MonoBehaviour
    {
        void OnTriggerEnter2D (Collider2D other)
        {
            if (other.transform.CompareTag("FieldOut1"))
            {
                Debug.Log("goool");
                Game.AddPoint(1);
            }
            else if (other.transform.CompareTag("FieldOut2"))
            {
                Debug.Log("goool");
                Game.AddPoint(2);
            }
        }
    }
}


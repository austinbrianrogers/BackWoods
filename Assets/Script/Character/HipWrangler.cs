using UnityEngine;
namespace ABR
{
    public class HipWrangler : MonoBehaviour
    {
        public float Rate = 1;
        public Vector3 Target;
        private void Update()
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Target, Rate);
        }
    }
}

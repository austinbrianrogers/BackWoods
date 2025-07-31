using UnityEngine;
using UnityEngine.Assertions;
namespace ABR
{
    public class BalloonBody : MonoBehaviour
    {
        [SerializeField]
        Rigidbody Body;

        [SerializeField]
        float Force;

        private void Start()
        {
            Assert.IsNotNull(Body);
        }

        private void Update()
        {
            Body.AddForce(Vector3.up * Force);
        }
    }
}

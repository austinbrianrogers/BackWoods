using ABR.Utilities;
using UnityEngine;
namespace ABR
{
    public class BalloonRigController : MonoBehaviour
    {
        [Header("Object Fields")]
        [SerializeField]
        Rigidbody LeftFoot;
        [SerializeField]
        Rigidbody RightFoot;
        [SerializeField]
        AnimationCurve FootRise;
        [SerializeField]
        AnimationCurve FootForward;

        [Header("Scalars")]
        [SerializeField]
        float RisingForce = 1; 
        [SerializeField]
        float GaitForce = 1;

        [Header("Timing (seconds) ")]
        [SerializeField]
        float StepTime = 2;


        private void Update()
        {
            if (_walking)
            {
                LeftFoot.AddForce(new Vector3(0f, getRise(rightFoot: false), 0f) * RisingForce);
                RightFoot.AddForce(new Vector3(0f, getRise(rightFoot: true), 0f) * RisingForce);

                LeftFoot.AddForce(new Vector3(0f, 0f, getGait(rightFoot: false)) * GaitForce);
                RightFoot.AddForce(new Vector3(0f, 0f, getGait(rightFoot: true)) * GaitForce);
            }
        }

        public void SetWalkingEnabled(bool enabled)
        {
            _walking = enabled;
        }

        float getRise(bool rightFoot = false)
        {
            _internalTime += Time.deltaTime;
            var diff = _internalTime - StepTime;
            if (diff >= 0)
                _internalTime = diff;

            var x = _internalTime / StepTime;
            var y = FootRise.Evaluate(x);

            return rightFoot? -y : y;
            
        }

        float getGait(bool rightFoot = false)
        {
            _internalTime += Time.deltaTime;
            var diff = _internalTime - StepTime;
            if (diff >= 0)
                _internalTime = diff;

            var x = _internalTime / StepTime;
            var y = FootRise.Evaluate(x);

            return rightFoot ? -y : y;

        }

        float _internalTime = 0f;
        bool _walking = false;
        Vector3 _cummunlativeMove = Vector3.zero;
    }
}

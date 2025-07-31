using ABR.Utilities;
using UnityEngine;
using UnityEngine.Assertions;
namespace ABR
{
    public class PlayerInputMaster : MonoBehaviour
    {
        [SerializeField]
        float Speed = 2;
        [SerializeField]
        Rigidbody MasterBody = null;
        [SerializeField]
        BalloonRigController BalloonRig = null;
        private void Start()
        {
            Assert.IsNotNull(MasterBody);
            Assert.IsNotNull(BalloonRig);
        }
        private void Update()
        {
            input();

        }
        private void LateUpdate()
        {
            if (_walking)
                transform.position += _cummulativeMove.normalized * Time.deltaTime * Speed;
        }

        void input()
        {
            _cummulativeMove = Vector3.zero;

            var fwd = transform.forward;
            var right = transform.right;

            if (InputManager.Instance.Key(KeyCode.W))
                _cummulativeMove += new Vector3(fwd.x, 0f, fwd.z);
            if (InputManager.Instance.Key(KeyCode.S))
                _cummulativeMove += new Vector3(-fwd.x, 0f, -fwd.z);
            if (InputManager.Instance.Key(KeyCode.A))
                _cummulativeMove += new Vector3(right.x, 0f, right.z);
            if (InputManager.Instance.Key(KeyCode.D))
                _cummulativeMove += new Vector3(-right.x, 0f, -right.z);

            if (_cummulativeMove.magnitude > 0)
                walk();
            else
                stopWalking();
        }

        void walk()
        {
            _walking = true;
            BalloonRig.SetWalkingEnabled(_walking);
        }

        void stopWalking()
        {
            _walking = false;
            BalloonRig.SetWalkingEnabled(_walking);
        }


        bool _walking = false;
        Vector3 _cummulativeMove = Vector3.zero;
    }
}

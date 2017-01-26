using UnityEngine;
using System.Collections;
// By @JavierBullrich

namespace SimpleMainMenu {
	public class BouncingBallScript : MonoBehaviour {
        Rigidbody rigidbody;
        private float addVelocity = 400f;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(new Vector3(addVelocity, addVelocity, 0));
        }

        void OnCollisionEnter(Collision collisionInfo)
        {
            rigidbody.AddForce(addVelocity * -(Mathf.Sign(rigidbody.velocity.x)), addVelocity, 0);
        }
    }
}
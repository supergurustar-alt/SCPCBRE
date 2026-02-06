using UnityEngine;

public class MobileForce : MonoBehaviour {
    public float speed = 5.0f;
    private CharacterController cc;

    void Update() {
        // 1. Find the Joystick (added via manifest.json)
        var joy = Object.FindObjectOfType<Joystick>();
        if (joy == null) return;

        // 2. Find the Player puppet
        if (cc == null) {
            GameObject p = GameObject.Find("Player") ?? GameObject.FindGameObjectWithTag("Player");
            if (p != null) cc = p.GetComponent<CharacterController>();
        }

        // 3. Force the move
        if (cc != null) {
            Vector3 move = new Vector3(joy.Horizontal, -9.81f, joy.Vertical);
            cc.Move(transform.TransformDirection(move) * speed * Time.deltaTime);
        }
    }
}

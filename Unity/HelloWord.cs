using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.Space))
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Destroy(obj);
        }
    }
}

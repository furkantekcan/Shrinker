using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed = 600f;

    float movement;
    // Start is called before the first frame update

    //void Start()
    //{
    //    
    //}

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() {

        transform.RotateAround(Vector3.zero, -Vector3.forward, movement * Time.deltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

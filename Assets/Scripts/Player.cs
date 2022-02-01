using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public delegate void onScoreAction();
    public static event onScoreAction onScoreChanged;

    public float moveSpeed = 600f;

    private PauseMenu pauseMenu;
    private float movement;

    // Start is called before the first frame update

    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() 
    {

        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.deltaTime * -moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.transform.name == "Trigger" )
        {
            if (onScoreChanged != null)
            {
                onScoreChanged();
            }
        }
        else
        {
           pauseMenu.Pause(); 
        }
        
    }
}

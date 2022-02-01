using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
  private float waitTime = 5.0f;
  private float speedTimer = 0f;
  private float speedWaitTime = 10f;
  private float dirTimer = 0.0f;
  private float rotVelocity = 30f;
  private int rotDir = 1;

  public delegate void onTimeChangeAction();
  public static event onTimeChangeAction onTimeChanged;

    // Start is called before the first frame update
    //void Start()
    //{
    //    
    //}

    // Update is called once per frame
    void Update()
    {
      speedTimer += Time.deltaTime;
      dirTimer += Time.deltaTime;
      if (dirTimer > waitTime)
      {
        dirTimer = 0;
        rotDir = -rotDir;
      }

      if (speedTimer > speedWaitTime)
      {
        speedTimer = 0;

        if (onTimeChanged != null)
      {
        onTimeChanged();
      }
      }


      transform.Rotate(Vector3.forward * rotDir, Time.deltaTime * rotVelocity); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodasNave: MonoBehaviour
{
    enum State : byte
    {
        Bounce, //0
        Float, //1
        Expand, //2
    }

  [SerializeField] private State currentState;
  [SerializeField] private Material material;
  [SerializeField] private Color floatingColor;
  [SerializeField] private Color normalColor;
  private Rigidbody rigidbody;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (currentState == State.Bounce)
        {
            if (Input.GetKeyDown((KeyCode)32))
            {
                currentState = State.Float;
                rigidbody.isKinematic = true;
                material.SetColor("_BaseColor",floatingColor);

            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                currentState = State.Expand;
                transform.localScale = Vector3.one * 5;

            }
        }
        else
        
            if ( currentState == State.Float && Input.GetKeyUp(KeyCode.Space))
            {
                currentState = State.Bounce;
                rigidbody.isKinematic = false;
                material.SetColor("_BaseColor",normalColor);
            }

            if (currentState == State.Expand&& Input.GetKeyUp(KeyCode.E))
            {
                currentState = State.Bounce;
                transform.localScale=Vector3.one;
                
            }
        }
    
    }


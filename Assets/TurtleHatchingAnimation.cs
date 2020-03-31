using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleHatchingAnimation : MonoBehaviour
{
    public Animator turtleHatchAnimator;

    public int randomPath;
    int randomSpeedPicker;
    public float randomSpeed;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        turtleHatchAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(waitCoroutine());
    }

    IEnumerator waitCoroutine()
    {
        NewAnimation();
        yield return new WaitForSeconds(time);
    }

    void NewAnimation()
    {
        randomPath = Random.Range(1, 6);
        randomSpeedPicker = Random.Range(1, 5);
        
        if (randomSpeedPicker == 1)
        {
            randomSpeed = 0.5f;
        }
        else if (randomSpeedPicker == 2)
        {
            randomSpeed = 0.75f;
        }
        else if (randomSpeedPicker == 3)
        {
            randomSpeed = 1.0f;
        }
        else if (randomSpeedPicker == 4)
        {
            randomSpeed = 1.5f;
        }

        turtleHatchAnimator.SetFloat("animationSpeed", randomSpeed);
        turtleHatchAnimator.SetInteger("randomPath", randomPath);
        time = (250 / 30) * randomSpeed;
    }
}

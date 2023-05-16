using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class _GameManager : MonoBehaviour
{
    [Header("---Balls Controller")]
    [SerializeField] private GameObject[] balls;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private float firePower;
    int activeBallIndex;
    [Header("---Levels Controller")]

    [SerializeField] private int targetBallsPoint;
    [SerializeField] private int availableBallsPoint;
    int enteringBallPoint;
    public Slider levelSlider;
    public TextMeshProUGUI remainderBalls_Text;

    public Animator anim;

    private void Start()
    {
        levelSlider.maxValue = targetBallsPoint;
        remainderBalls_Text.text = availableBallsPoint.ToString();
       


    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("Cannon");
            balls[activeBallIndex].transform.SetPositionAndRotation(firePoint.transform.position, firePoint.transform.rotation);
            balls[activeBallIndex].gameObject.SetActive(true);
            balls[activeBallIndex].GetComponent<Rigidbody>().AddForce(balls[activeBallIndex].transform.TransformDirection(90, 90, 0) * firePower, ForceMode.Force);


            if (balls.Length - 1 == activeBallIndex)
            {
                activeBallIndex = 0;
            }
            else
                activeBallIndex++;
        }
        
    }

    public void successfulShot()
    {
       enteringBallPoint++;
        levelSlider.value = enteringBallPoint;
        availableBallsPoint--;
        remainderBalls_Text.text=availableBallsPoint.ToString();
        
    }
    public void unSuccessfulShot()
    {
        availableBallsPoint--;
        remainderBalls_Text.text = availableBallsPoint.ToString();
    }



}

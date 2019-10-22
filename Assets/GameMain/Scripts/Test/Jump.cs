
using System;
using DG.Tweening;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    
    private RaycastHit2D rayhit;
    
    public LayerMask groundLayer;

    private bool isJump;
    
    private float m_Time = 1f;

    private float curTime = 0;

    private float m_DownAddSpeed = 1f; //加速度

    private float m_DownCurTime = 0;

    private float m_JumpAddSpeed = 0.1f;

    private float m_JumpStartSpeed = 0.5f;

    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        isJump = false;
    }

    void Update()
    {
        //画射线
        Debug.DrawRay(transform.position, Vector2.down*0.7f , Color.red);
        
        rayhit = Physics2D.Raycast(transform.position, Vector2.down, 0.7f,groundLayer);

        if (rayhit.collider == null && !isJump)
        {
            m_DownCurTime += Time.deltaTime;
            //当下方没有碰撞体 和不在跳跃状态下 进行自由落体运动
            transform.position -= new Vector3(0,m_DownAddSpeed*m_DownCurTime,0);
        }
        else
        {
           // 当有碰撞体的时候进行跳跃

            isJump = true;
//            if (curTime < m_Time && m_JumpStartSpeed>0)
//            {
//                curTime+=Time.deltaTime;
//                m_JumpStartSpeed = m_JumpStartSpeed-m_JumpAddSpeed*curTime;
//                transform.position += new Vector3(0,m_JumpStartSpeed,0);
//            }
//            else
//            {
//                m_DownCurTime = 0;
//                m_JumpStartSpeed =  0.5f;
//                curTime = 0;
//                isJump = false;
//            }


            transform.DOLocalMoveY(transform.localPosition.y+1, 0.3f).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                isJump = false;
                m_DownCurTime = 0;
            });
        }

        //控制左右移动
        
        float Hor = Input.GetAxis("Horizontal");//当你按‘a’'d'键返回一个[-1，1]的值
        transform.position += Vector3.right * Hor * Time.deltaTime * 5;
    }


}

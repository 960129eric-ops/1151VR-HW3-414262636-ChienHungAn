using System.Collections;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [Header("音效設定")]
    public AudioSource audioSource;   // 掛載 Audio Source 的元件
    public AudioClip spinSound;       // 旋轉時播放的音效

    [Header("轉動參數設定")]
    public float maxSpeed = 1200f;    // 最大旋轉速度 (度/秒)
    public float acceleration = 600f; // 加速度
    public float deceleration = 600f; // 減速度

    private bool isSpinning = false;
    private bool isStopping = false;
    private float currentSpeed = 0f;

    void Start()
    {
        // 初始化音效設定
        if (audioSource != null && spinSound != null)
        {
            audioSource.clip = spinSound;
            audioSource.loop = true; // 設定音效循環播放
        }
    }

    void Update()
    {
        // 按下空白鍵控制開始與停止
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isSpinning)
            {
                StartSpin();
            }
            else if (!isStopping)
            {
                StopSpin();
            }
        }

        // 當處於旋轉狀態時，依照當前速度轉動輪盤
        if (isSpinning)
        {
            transform.Rotate(0, 0, -currentSpeed * Time.deltaTime);
        }
    }

    public void StartSpin()
    {
        StopAllCoroutines();
        isSpinning = true;
        isStopping = false;
        StartCoroutine(AccelerateRoutine());
    }

    public void StopSpin()
    {
        StopAllCoroutines();
        StartCoroutine(DecelerateRoutine());
    }

    private IEnumerator AccelerateRoutine()
    {
        // 開始播放音效
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // 加速階段
        while (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            yield return null;
        }
        currentSpeed = maxSpeed;
    }

    private IEnumerator DecelerateRoutine()
    {
        isStopping = true;

        // 減速階段
        while (currentSpeed > 0f)
        {
            currentSpeed -= deceleration * Time.deltaTime;
            yield return null;
        }
        currentSpeed = 0f;

        // 停止播放音效
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        isSpinning = false;
        isStopping = false;
    }
}
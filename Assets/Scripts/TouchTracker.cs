using UnityEngine;
using UnityEngine.UI;

public class TouchTracker : MonoBehaviour
{
    [Header("UI References")]
    public Text touchPositionText;
    
    [Header("Settings")]
    public float longPressDuration = 1.0f;
    
    private bool isLongPress = false;
    private float pressStartTime;
    private bool isTouching = false;

    void Start()
    {
        if(touchPositionText != null)
            touchPositionText.text = "等待触摸输入...";
    }

    void Update()
    {
        // 优先使用触摸输入
        if (Input.touchCount > 0)
        {
            HandleTouch(Input.GetTouch(0));
        }
        // 编辑器内用鼠标模拟
        else if (Application.isEditor && Input.GetMouseButton(0))
        {
            SimulateTouchWithMouse();
        }
        else if (isTouching)
        {
            EndTouch();
        }
    }

    void HandleTouch(Touch touch)
    {
        switch (touch.phase)
        {
            case TouchPhase.Began:
                StartTouch(touch.position);
                break;
                
            case TouchPhase.Stationary:
            case TouchPhase.Moved:
                UpdateTouch(touch.position);
                break;
                
            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                EndTouch();
                break;
        }
    }

    void SimulateTouchWithMouse()
    {
        if (!isTouching)
        {
            StartTouch(Input.mousePosition);
        }
        else
        {
            UpdateTouch(Input.mousePosition);
        }
    }

    void StartTouch(Vector2 position)
    {
        isTouching = true;
        pressStartTime = Time.time;
        isLongPress = false;
        UpdateDisplay(position, "触摸开始");
    }

    void UpdateTouch(Vector2 position)
    {
        if (Time.time - pressStartTime > longPressDuration && !isLongPress)
        {
            isLongPress = true;
            UpdateDisplay(position, "长按中");
        }
        else
        {
            string status = isLongPress ? "长按滑动中" : "滑动中";
            UpdateDisplay(position, status);
        }
    }

    void EndTouch()
    {
        isTouching = false;
        UpdateDisplay(Vector2.zero, isLongPress ? "长按结束" : "点击结束");
        isLongPress = false;
    }

    void UpdateDisplay(Vector2 position, string status)
    {
        string displayText;
        
        if (status.Contains("结束"))
        {
            displayText = status;
        }
        else
        {
            displayText = $"{status}\n" +
                         $"屏幕坐标:\n" +
                         $"X: {position.x:F0}\n" +
                         $"Y: {position.y:F0}\n" +
                         $"时长: {Time.time - pressStartTime:F2}s";
        }

        if (touchPositionText != null)
        {
            touchPositionText.text = displayText;
        }
        
        Debug.Log(displayText);
    }
}
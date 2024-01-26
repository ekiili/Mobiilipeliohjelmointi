using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    private int a = 0;
    private int b = 1;
    private int frameCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Frame 1: 0");
    }

    // Update is called once per frame
    void Update()
    {
        if (b > 1000) return;

        frameCount++;
        Debug.Log($"Frame {frameCount}: {b}");

        int temp = a;
        a = b;
        b = temp + b;
    }
}
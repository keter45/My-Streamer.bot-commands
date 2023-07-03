using System;
using System.Runtime.InteropServices;

public class MouseOperations
{
    [DllImport("user32.dll")]
    private static extern bool SetCursorPos(int x, int y);

    [DllImport("user32.dll")]
    private static extern bool GetCursorPos(out MousePoint lpMousePoint);

    [DllImport("user32.dll")]
    private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const int MOUSEEVENTF_LEFTUP = 0x0004;

    public struct MousePoint
    {
        public int X;
        public int Y;

        public MousePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public static void SetCursorPosition(int x, int y)
    {
        SetCursorPos(x, y);
    }

    public static MousePoint GetCursorPosition()
    {
        MousePoint currentMousePoint;
        var gotPoint = GetCursorPos(out currentMousePoint);
        if (!gotPoint)
        {
            currentMousePoint = new MousePoint(0, 0);
        }

        return currentMousePoint;
    }

    public static void SimulateLeftClick(int x, int y)
    {
        SetCursorPosition(x, y);
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, 0);
    }
}


public class CPHInline
{
    public bool Execute()
    {
        var currentScene = CPH.ObsGetCurrentScene();
        if (currentScene != "lobby")
        {
            CPH.SendMessage("Nem tamo na fila, safado");
            return true;
        }

        MouseOperations.SimulateLeftClick(938, 709);
        return true;
    }
}
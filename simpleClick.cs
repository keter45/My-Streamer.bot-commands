using System;
using System.Runtime.InteropServices;

public class MouseSimulator
{
    [DllImport("user32.dll")]
    private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

    private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
    private const uint MOUSEEVENTF_LEFTUP = 0x0004;

    public static void SimulateLeftClick(uint x, uint y)
    {
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, x, y, 0, UIntPtr.Zero);
    }
}

public class CPHInline
{
	public bool Execute()
	{
		MouseSimulator.SimulateLeftClick(0, 0);
		return true;
	}
}

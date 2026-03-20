using System;
using System.Runtime.InteropServices;

public static class Taskbar
{
    private const int ABM_GETTASKBARPOS = 0x00000005;

    private enum ABEdge : uint
    {
        ABE_LEFT = 0,
        ABE_TOP = 1,
        ABE_RIGHT = 2,
        ABE_BOTTOM = 3
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct APPBARDATA
    {
        public uint cbSize;
        public IntPtr hWnd;
        public uint uCallbackMessage;
        public ABEdge uEdge;
        public RECT rc;
        public int lParam;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    [DllImport("shell32.dll")]
    private static extern uint SHAppBarMessage(uint dwMessage, ref APPBARDATA pData);

    public static int GetTaskbarSize()
    {
        APPBARDATA data = new APPBARDATA();
        data.cbSize = (uint)Marshal.SizeOf(typeof(APPBARDATA));

        uint result = SHAppBarMessage(ABM_GETTASKBARPOS, ref data);

        if (result == 0)
            return 0; // No se pudo obtener

        RECT r = data.rc;

        // Si la barra está arriba o abajo → altura
        if (data.uEdge == ABEdge.ABE_TOP || data.uEdge == ABEdge.ABE_BOTTOM)
            return Math.Abs(r.bottom - r.top);

        // Si está a izquierda o derecha → ancho
        return Math.Abs(r.right - r.left);
    }
}


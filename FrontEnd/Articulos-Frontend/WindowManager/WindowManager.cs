
using System;
using System.Collections.Generic;
using System.Text;

namespace Articulos_Frontend;

public static class WindowManager
{

    private static Dictionary<string, FormMT> _openWindows = new();

    public static event Action OnWindowsChanged;

    public static IReadOnlyDictionary<string, FormMT> OpenWindows => _openWindows;

    public static void Activate(string key)
    {
        if(_openWindows.TryGetValue(key, out var form))
        {
            if (form.formularioHijo.WindowState == FormWindowState.Minimized)
            {
                form.formularioHijo.WindowState = FormWindowState.Normal;
            }     

            form.formularioHijo.BringToFront();
        }
    }

    public static void ShowForm<T>(string key, Form owner, Func<T> factory) where T : Form
    {
        if (_openWindows.ContainsKey(key))
        {
            var form = _openWindows[key];

            if (form.formularioHijo.WindowState == FormWindowState.Minimized)
                form.formularioHijo.WindowState = FormWindowState.Normal;

            form.formularioHijo.BringToFront();
            return;
        }

        var newForm = new FormMT(owner, factory());
        
        newForm.formularioHijo.Owner = owner;

        _openWindows[key] = newForm;

        OnWindowsChanged?.Invoke();

        newForm.formularioHijo.FormClosed += (s, e) =>
        {
            _openWindows.Remove(key);
            OnWindowsChanged?.Invoke();
        };
        int desplazamiento = 0;
        if (owner is Menu m)
        {
            desplazamiento = m.getMenuStripHeigth(); //(owner.Height - owner.ClientSize.Height) + m.getMenuStripHeigth();
        }

        newForm.formularioHijo.Width = newForm.formularioPadre.Width;
        newForm.formularioHijo.Height = newForm.formularioPadre.Height;
        newForm.formularioHijo.Load += (s, e) =>
        {
            if (owner is  Menu m)
            {
                newForm.formularioHijo.Width = owner.Width;
                newForm.formularioHijo.Height = owner.ClientSize.Height - m.getMenuStripHeigth();
                // MessageBox.Show($"{Taskbar.GetTaskbarSize}");

                int x = owner.Left;
                int y = owner.Top;

                newForm.formularioHijo.Location = new Point(
                    m.Left + (m.Width - newForm.formularioHijo.Width) / 2,
                    m.Top + ((m.Height - newForm.formularioHijo.Height) / 2) + m.getMenuStripHeigth()
                );
            }
        };  
        newForm.formularioHijo.Show();
    }
}



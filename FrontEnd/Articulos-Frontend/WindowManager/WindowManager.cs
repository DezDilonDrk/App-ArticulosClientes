
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
            form.formularioHijo.Activate();

            form.formularioHijo.TopMost = true;
            form.formularioHijo.TopMost = false;
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
            form.formularioHijo.Activate();
            return;
        }

        var newForm = new FormMT(owner, factory());

        _openWindows[key] = newForm;

        OnWindowsChanged?.Invoke();

        newForm.formularioHijo.FormClosed += (s, e) =>
        {
            _openWindows.Remove(key);
            OnWindowsChanged?.Invoke();
        };
        newForm.formularioHijo.Width = newForm.formularioPadre.Width - 40;
        newForm.formularioHijo.Height = newForm.formularioPadre.Height - 140;
        newForm.formularioHijo.Shown += (s, e) =>
        {
            if (owner != null)
            {
                newForm.formularioHijo.Location = new Point(
                    owner.Left + (owner.Width - newForm.formularioHijo.Width) / 2,
                    owner.Top + (owner.Height - newForm.formularioHijo.Height) / 2
                );
            }
        };  
        newForm.formularioHijo.Show();
    }
}



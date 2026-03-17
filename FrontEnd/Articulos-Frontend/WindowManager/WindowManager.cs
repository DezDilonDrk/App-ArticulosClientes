
using System;
using System.Collections.Generic;
using System.Text;

namespace Articulos_Frontend;

public static class WindowManager
{

    private static Dictionary<string, FormMT> _openWindows = new();

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

        newForm.formularioHijo.FormClosed += (s, e) =>
        {
            _openWindows.Remove(key);
        };
        newForm.formularioHijo.Width = 900;
        newForm.formularioHijo.Height = 520;
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



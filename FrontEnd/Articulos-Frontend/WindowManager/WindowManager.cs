using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Articulos_Frontend;

public static class WindowManager
{

    private static Dictionary<string, Form> _openWindows = new();

    public static void ShowForm<T>(string key, Form owner, Func<T> factory) where T : Form
    {
        if (_openWindows.ContainsKey(key))
        {
            var form = _openWindows[key];

            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Normal;

            form.BringToFront();
            form.Activate();
            return;
        }

        var newForm = factory();

        _openWindows[key] = newForm;

        newForm.FormClosed += (s, e) =>
        {
            _openWindows.Remove(key);
        };
        newForm.Width = 900;
        newForm.Height = 520;
        newForm.Shown += (s, e) =>
        {
            if (owner != null)
            {
                newForm.Location = new Point(
                    owner.Left + (owner.Width - newForm.Width) / 2,
                    owner.Top + (owner.Height - newForm.Height) / 2
                );
            }
        };  
        newForm.Show();
    }
}



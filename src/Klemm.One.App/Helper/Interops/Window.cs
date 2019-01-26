﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Klemm.One.App.Helper.Interops
{
    public class Window
    {
        public static Task<object> Open(string url, string target = "_blank")
        {
            return JSRuntime.Current.InvokeAsync<object>("open", url, target);
        }
    }
}

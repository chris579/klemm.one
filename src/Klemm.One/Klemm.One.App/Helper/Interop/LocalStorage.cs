using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Klemm.One.App.Helper.Interop
{
    public static class LocalStorage
    {
        public static Task SetItem(string key, string value)
        {
            return JSRuntime.Current.InvokeAsync<object>("localStorageInterop.setItem",  key, value);
        }

        public static Task<string> GetItem(string key)
        {
            return JSRuntime.Current.InvokeAsync<string>("localStorageInterop.getItem", key);
        }

        public static Task RemoveItem(string key)
        {
            return JSRuntime.Current.InvokeAsync<object>("localStorageInterop.removeItem", key);
        }

        public static Task Clear()
        {
            return JSRuntime.Current.InvokeAsync<object>("localStorageInterop.clear");
        }

        public static async Task<Dictionary<string, string>> GetAllItems()
        {
            var items = await JSRuntime.Current.InvokeAsync<string[][]>("localStorageInterop.getAllItems");
            return items.ToDictionary(x => x[0], x => x[1]);
        }
    }
}

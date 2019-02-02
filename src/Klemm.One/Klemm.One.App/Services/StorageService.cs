using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klemm.One.App.Helper.Interop;

namespace Klemm.One.App.Services
{
    public class StorageService
    {
        private const string StorageAcceptKey = "storageAccepted";

        public bool IsEnabled { get; set; }

        public event EventHandler<bool> StateChanged;

        public async Task Init()
        {
            var storageFlag = await LocalStorage.GetItem(Properties.Resources.StorageKey + StorageAcceptKey);
            IsEnabled = !string.IsNullOrEmpty(storageFlag);
        }

        public async Task AcceptStorage()
        {
            await SessionStorage.SetItem(Properties.Resources.StorageKey + StorageAcceptKey, true.ToString());

            var items = await SessionStorage.GetAllItems();
            foreach (var item in items)
            {
                await LocalStorage.SetItem(item.Key, item.Value);
            }

            await SessionStorage.Clear();

            IsEnabled = true;
            StateChanged?.Invoke(this, true);
        }

        public async Task DenyStorage()
        {
            await LocalStorage.RemoveItem(Properties.Resources.StorageKey + StorageAcceptKey);

            var items = await LocalStorage.GetAllItems();
            foreach (var item in items)
            {
                await SessionStorage.SetItem(item.Key, item.Value);
            }

            await LocalStorage.Clear();

            IsEnabled = false;
            StateChanged?.Invoke(this, false);
        }

        public Task SetItem(string key, string value)
        {
            return IsEnabled
                ? LocalStorage.SetItem(Properties.Resources.StorageKey + key, value)
                : SessionStorage.SetItem(Properties.Resources.StorageKey + key, value);
        }

        public Task<string> GetItem(string key)
        {
            return IsEnabled
                ? LocalStorage.GetItem(Properties.Resources.StorageKey + key)
                : SessionStorage.GetItem(Properties.Resources.StorageKey + key);
        }
    }
}

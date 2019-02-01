using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Klemm.One.App.Helper.Interops;

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
            await LocalStorage.SetItem(Properties.Resources.StorageKey + StorageAcceptKey, true.ToString());

            IsEnabled = true;
            StateChanged?.Invoke(this, true);
        }

        public async Task DenyStorage()
        {
            await LocalStorage.RemoveItem(Properties.Resources.StorageKey + StorageAcceptKey);

            IsEnabled = false;
            StateChanged?.Invoke(this, false);
        }
    }
}

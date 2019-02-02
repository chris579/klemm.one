window.sessionStorageInterop = {
    setItem: function (key, value) {
        sessionStorage.setItem(key, value);
    },
    getItem: function (key) {
        return sessionStorage.getItem(key);
    },
    removeItem: function (key) {
	    sessionStorage.removeItem(key);
    },
    clear: function () {
	    sessionStorage.clear();
    },
    getAllItems: function () {
	    const archive = [];
	    const keys = Object.keys(sessionStorage);

	    keys.forEach(key => {
            archive.push([key, sessionStorage.getItem(key)]);
	    });

	    return archive;
    }
};
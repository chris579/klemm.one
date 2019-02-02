window.localStorageInterop = {
	setItem: function (key, value) {
		localStorage.setItem(key, value);
	},
	getItem: function (key) {
		return localStorage.getItem(key);
	},
	removeItem: function (key) {
		localStorage.removeItem(key);
	},
	clear: function () {
		localStorage.clear();
	},
	getAllItems: function () {
		const archive = [];
		const keys = Object.keys(localStorage);

		keys.forEach(key => {
			archive.push([key, localStorage.getItem(key)]);
		});

		return archive;
	}
};
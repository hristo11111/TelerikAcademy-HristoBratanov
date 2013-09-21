/// <reference path="../libs/_references.js" />


window.viewsFactory = (function () {
	var rootUrl = "Scripts/partials/";

	var templates = {};

	function getTemplate(name) {
		var promise = new RSVP.Promise(function (resolve, reject) {
			if (templates[name]) {
				resolve(templates[name])
			}
			else {
				$.ajax({
					url: rootUrl + name + ".html",
					type: "GET",
					success: function (templateHtml) {
						templates[name] = templateHtml;
						resolve(templateHtml);
					},
					error: function (err) {
						reject(err)
					}
				});
			}
		});
		return promise;
	}

	function getMenuView() {
	    return getTemplate("menu");
	};

	function getLoginView() {
		return getTemplate("login-form");
	}

	function getCreateAppointmentView() {
	    return getTemplate("create-appointment");
	}

	function getAppointmentsView() {
	    return getTemplate("all-appointments");
	}

	function getTodoListView() {
        return getTemplate("todo-list")
	}

	return {
	    getLoginView: getLoginView,
	    getMenuView: getMenuView,
	    getCreateAppointmentView : getCreateAppointmentView,
	    getAppointmentsView: getAppointmentsView,
	    getTodoListView: getTodoListView
	};
}());
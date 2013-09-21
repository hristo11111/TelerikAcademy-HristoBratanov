/// <reference path="libs/_references.js" />


(function () {
	var appLayout =
		new kendo.Layout('<nav id="nav"></nav><div id="main-content"></div>');
	var data = persisters.get("api/");
	vmFactory.setPersister(data);

	var router = new kendo.Router();

	router.route("/", function () {
	    if (data.isUserLoggedIn()) {
	        router.navigate("/home");
	    }
	    else {
	        viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(
						function () {
						    var accessToken = localStorage.getItem("accessToken");
						    if (accessToken) {
						        router.navigate("/home");
						    }
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    $("#nav").empty();
				    appLayout.showIn("#main-content", view);
				}, function (error) {
				    console.log(error);
				});
	    }
	});

	router.route("/home", function () {
	    viewsFactory.getMenuView()
            .then(function (menuHTML) {
                var accessToken = localStorage.getItem("accessToken");
                if (!accessToken) {
                    console.log("Invalid acces token");
                    router.navigate("/");
                }
                else {
                    var nicknameVm = vmFactory.getNicknameVM();
                    var view = new kendo.View(menuHTML,
                            { model: nicknameVm });
                    appLayout.showIn("#nav", view);
                    //$(".menu").kendoMenu();
                    var welcome = kendo.View("<div>asd</div>");
                    appLayout.showIn("#main-content", welcome);
                }
            });
	});

	router.route("/logout", function () {
	    data.users.logout()
            .then(function (data) {
                router.navigate("/");
            }, function (error) {
                console.log(error);
            });
	});

	//router.route("/createAppointment", function () {
	//    viewsFactory.getCreateAppointmentView()
    //        .then(function (createAppointmentHtml) {
    //            var vm = vmFactory.getCreateAppointmentVM();
    //            var view = new kendo.View(createAppointmentHtml,
    //                { model: vm });
    //            appLayout.showIn("#main-content", view);
    //        }, function (err) {
    //            console.log(err);
    //        });
	//});

	router.route("/allappointments", function () {
	    viewsFactory.getAppointmentsView()
            .then(function (allAppointmentsHtml) {
                vmFactory.getAppointmentsVM()
                    .then(function (vm) {
                        var view = new kendo.View(allAppointmentsHtml,
                            { model: vm });
                        appLayout.showIn("#main-content", view);
                    }, function (err) {
                        console.log(err);
                    });
            }, function (err) {
                console.log(err);
            });
	});

	router.route("/todo-list", function () {
	    viewsFactory.getTodoListView()
            .then(function (todoListHtml) {
                vmFactory.getTodoListVM()
                    .then(function (vm) {
                        var view = new kendo.View(todoListHtml,
                            { model: vm });
                        appLayout.showIn("#main-content", view);
                    }, function (err) {
                        console.log(err);
                    });
            }, function (err) {
                console.log(err);
            });
	});

	//router.route("/todo-list/:id"), function () {
	//}

	$(function () {
		appLayout.render("#app");
		router.start();

		viewsFactory.getMenuView()
            .then(function (menuHTML) {
                var accessToken = localStorage.getItem("accessToken");
                if (!accessToken) {
                    console.log("Invalid acces token");
                    router.navigate("/");
                }
                else {
                    var nicknameVm = vmFactory.getNicknameVM();
                    var view = new kendo.View(menuHTML,
                            { model: nicknameVm });
                    appLayout.showIn("#nav", view);
                    //$(".menu").kendoMenu();
                    var welcome = kendo.View("<div>asd</div>");
                    var role = localStorage.getItem("role");
                    if (role == "admin") {
                        $(".admin-link").show();
                    }
                    appLayout.showIn("#main-content", welcome);
                }
            });
	});
}());
/// <reference path="libs/_references.js" />

(function () {
    var appLayout = new kendo.Layout('<div id="main-content"></div>');
    var data = persisters.get("api/");

    vmFactory.setPersister(data);

    var router = new kendo.Router();
    router.route("/", function () {
        viewsFactory.getCarsView()
            .then(function (carsViewHtml) {
                vmFactory.getCarsVM()
                .then(function (vm) {
                    var view =
                        new kendo.View(carsViewHtml,
                        { model: vm });
                    appLayout.showIn("#main-content", view);
                }, function (err) {
                    //...
                });
            });
    });

    router.route("/home", function () {
        viewsFactory.getCarsView()
            .then(function (carsViewHtml) {
                vmFactory.getCarsVM()
                .then(function (vm) {
                    var view =
                        new kendo.View(carsViewHtml,
                        { model: vm });
                    appLayout.showIn("#main-content", view);
                }, function (err) {
                    //...
                });
            });
    });

    router.route("/cars", function () {
        viewsFactory.getCarsView()
            .then(function (carsViewHtml) {
                vmFactory.getCarsVM()
                .then(function (vm) {
                    var view =
                        new kendo.View(carsViewHtml,
                        { model: vm });
                    appLayout.showIn("#main-content", view);
                }, function (err) {
                    //...
                });
            });
    });

    router.route("/login", function () {
        debugger;
        if (data.users.currentUser()) {
            router.navigate("/");
        }
        else {      
            viewsFactory.getLoginView()
				.then(function (loginViewHtml) {
				    var loginVm = vmFactory.getLoginVM(
						function () {
						    router.navigate("/");
						});
				    var view = new kendo.View(loginViewHtml,
						{ model: loginVm });
				    appLayout.showIn("#main-content", view);
				});
        }
    });

    $(function () {
        appLayout.render("#app");
        router.start();
    });
}());
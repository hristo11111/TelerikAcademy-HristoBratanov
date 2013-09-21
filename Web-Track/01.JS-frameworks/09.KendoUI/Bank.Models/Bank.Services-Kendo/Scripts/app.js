/// <reference path="libs/_references.js" />

(function () {
    var appLayout = new kendo.Layout('<div id="main-content"></div>');
    var data = persisters.get("api/");

    vmFactory.setPersister(data);

    var router = new kendo.Router();
    router.route("/", function () {
        
    });

    router.route("/home", function () {
        
    });

    router.route("/user", function () {
        viewsFactory.getUserView()
            .then(function (userViewHtml) {
                vmFactory.getUserVM()
                .then(function (vm) {
                    var view =
                        new kendo.View(userViewHtml,
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
            router.navigate("/home");
        }
        else {
            viewsFactory.getLoginView()
                .then(function (loginViewHtml) {
                    var loginVm = vmFactory.getLoginVM(
                        function () {
                            router.navigate("/user");
                        });
                    var view = new kendo.View(loginViewHtml,
                        { model: loginVm });
                    appLayout.showIn("#main-content", view);
                });
        }
    });

    router.route("/logout", function () {
        debugger;
        if (data.users.currentUser()) {
            router.navigate("/");
        }
        data.users.logout()
            .then(function (data) {
                router.navigate("/login");
            }, function (error) {
                console.log(error);
            });
    });

    router.route("/deposit", function () {
        viewsFactory.getDepositView()
            .then(function (depositViewHtml) {
                var depositVm = vmFactory.getDepositVM(
                    function () {
                        router.navigate("/user");
                    });
                var view =
                    new kendo.View(depositViewHtml,
                    { model: depositVm });
                appLayout.showIn("#main-content", view);
            });
    });

    router.route("/withdraw", function () {
        viewsFactory.getWithdrawView()
            .then(function (withdrawViewHtml) {
                var withdrawVm = vmFactory.getWithdrawVM(
                    function () {
                        router.navigate("/user");
                    });
                var view =
                    new kendo.View(withdrawViewHtml,
                    { model: withdrawVm });
                appLayout.showIn("#main-content", view);
            });
    });

    router.route("/transactions", function () {
        viewsFactory.getTransactionsView()
            .then(function (transactionViewHtml) {
                vmFactory.getTransactionsVM()
                .then(function (vm) {
                    var view =
                        new kendo.View(transactionViewHtml,
                        { model: vm });
                    appLayout.showIn("#main-content", view);
                }, function (err) {
                    //...
                });
            });
    });

    $(function () {
        appLayout.render("#app");
        router.start();
    });
}());
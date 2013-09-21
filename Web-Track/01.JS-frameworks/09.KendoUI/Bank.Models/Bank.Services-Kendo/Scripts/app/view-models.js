/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
    var data = null;

    function getLoginViewModel(successCallback) {
        var viewModel = {
            //username: "DonchoMinkov",
            //password: "123456q",
            login: function () {
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					});
            },
            register: function () {
                data.users.register(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					});
            }
        };
        return kendo.observable(viewModel);
    };

    function getUserViewModel() {
        return data.users.getUser()
			.then(function (user) {
			    var viewModel = {
			        user: user,
			        message: ""
			    };

			    return kendo.observable(viewModel);
			});
    }

    function getDepositModel() {
        var viewModel = {
            deposit: function () {
                data.users.deposit(this.get("Amount"))
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    });
            }
        }

        return kendo.observable(viewModel);
    }

    function getWithdrawModel() {
        var viewModel = {
            withdraw: function () {
                data.users.withdraw(this.get("Amount"))
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    });
            }
        }

        return kendo.observable(viewModel);
    }

    function getTransactionsModel() {
        return data.transactions.getTransactions()
			.then(function (transactions) {
			    var viewModel = {
			        transactions: transactions,
			        message: ""
			    };

			    return kendo.observable(viewModel);
			});
    }

    return {
        getLoginVM: getLoginViewModel,
        getUserVM: getUserViewModel,
        getDepositVM: getDepositModel,
        getWithdrawVM: getWithdrawModel,
        getTransactionsVM: getTransactionsModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());
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

    function getCarsViewModel() {
        return data.cars.all()
			.then(function (cars) {
			    var carsDataSource = new kendo.data.DataSource({
			        data: cars
			    });

			    var sorting = [
                    { field: 'make', dir: 'asc' },
                    { field: 'model', dir: 'asc' }
			    ];

			    carsDataSource.sort(sorting);
                
			    var viewModel = {
			        cars: cars,
			        message: ""
			    };
			    var sds = carsDataSource.view();

			    return kendo.observable({ cars: carsDataSource.view() });
			});
    }

    return {
        getLoginVM: getLoginViewModel,
        getCarsVM: getCarsViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());
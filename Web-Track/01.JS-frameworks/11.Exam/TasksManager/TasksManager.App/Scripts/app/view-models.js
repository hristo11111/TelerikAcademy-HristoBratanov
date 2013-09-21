/// <reference path="../libs/_references.js" />

window.vmFactory = (function () {
	var data = null;

	function getLoginViewModel(successCallback) {		
		var viewModel = {
			username: $("#tb-username").val(),
			password: $("#tb-password").val(),
			usernameReg: $("#tb-usernameReg").val(),
			passwordReg: $("#tb-passwordReg").val(),
			email: $("#tb-email").val(),
			login: function () {
				data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
							successCallback();
						}
					});
			},
			register: function () {
			    data.users.register(this.get("usernameReg"), this.get("passwordReg"),
                    this.get("email"))
					.then(function () {
						if (successCallback) {
							successCallback();
						}
					});
			}
		};
		return kendo.observable(viewModel);
	};

	function getCreateAppointmentViewModel(){
	    var viewModel = {
	        createAppointment: function () {
	            data.appointments.createAppointment(this.get("subject"), this.get("description"),
                    this.get("appointmentDate"), this.get("duration"))
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    });
	        }
	    }

	    return kendo.observable(viewModel);
	};

	function getAppointmentsViewModel() {
	    return data.appointments.all()
            .then(function (appointments) {
                var appDataSource = new kendo.data.DataSource({
                    data: appointments,
                });

                var sorting = { field: 'appointmentDate', dir: 'asc' };

                appDataSource.sort(sorting);

                var viewModel = {
                    appointments: appointments,
                    createAppointment: function () {
                        data.appointments.createAppointment(this.get("subject"), this.get("description"),
                        this.get("appointmentDate"), this.get("duration")).then(function (data) {
                            console.log(data);
                            console.log("success create");
                            viewModel.appointments = data;
                            kendo.bind(document.body, viewModel);
                        }, function (err) {
                            console.log(err);
                        });
                    }
                }

                return kendo.observable(viewModel);
            }, function (err) {
                console.log(err);
            });
	}

	function getTodoListViewModel() {
	    return data.todos.all()
            .then(function (todos) {
                var viewModel = {
                    todos: todos
                }
                return kendo.observable(viewModel);
            }, function (err) {
                console.log(err);
            });
	}
    
	function getNicknameViewModel() {
	    var viewModel ={
	        username: data.getNickname()
	    }
	    return kendo.observable(viewModel);
	}


	return {
	    getLoginVM: getLoginViewModel,
	    getCreateAppointmentVM: getCreateAppointmentViewModel,
	    getAppointmentsVM: getAppointmentsViewModel,
	    getTodoListVM: getTodoListViewModel,
		
	    getNicknameVM: getNicknameViewModel,

		setPersister: function (persister) {
			data = persister
		}
	};
}());
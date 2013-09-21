﻿/// <reference path="../libs/_references.js" />


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

	function getLoginView() {
		return getTemplate("login-form");
	}

	function getProductsView() {
	    return getTemplate("products");
	}

	function getMenuView() {
	    return getTemplate("menu");
	};

	function getProductsByIdView() {
	    return getTemplate("products-by-id");
	}

	function getCategoriesView() {
	    return getTemplate("categories");
	}

	function getBasketView() {
	    return getTemplate("basket");
	}

	return {
		getLoginView: getLoginView,
		getProductsView: getProductsView,
		getMenuView: getMenuView,
		getProductsById: getProductsByIdView,
		getCategoriesView: getCategoriesView,
		getCategoriesById: getProductsView,
		getBasketView: getBasketView
	};
}());
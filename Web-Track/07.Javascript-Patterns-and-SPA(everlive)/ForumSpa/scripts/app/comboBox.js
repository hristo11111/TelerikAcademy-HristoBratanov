﻿/// <reference path="../Libs/require.js" />
define(["classCreator"], function (Class) {
    var comboBox = comboBox || {};
    var ListView = Class.create({
        init: function (sourceItems) {
            if (!(sourceItems instanceof Array)) {
                throw "The data should be Array!"
            }
            this.sourceItems = sourceItems;
        },
        render: function (template) {
            var list = document.createElement("Select");
            list.className = "selected"
            for (var i = 0; i < this.sourceItems.length; i++) {
                var listItem = document.createElement("option");
                var item = this.sourceItems[i];
                listItem.setAttribute("data-id", item.id)
                listItem.innerHTML = template(item);
                list.appendChild(listItem);
            }

            return list.outerHTML;
        }
    });

    comboBox.listView = function (sourceItems) {
        return new ListView(sourceItems);
    }

    return comboBox;
});
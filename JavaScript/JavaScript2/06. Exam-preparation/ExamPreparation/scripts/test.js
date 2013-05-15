var controls = (function () {
    function hidePrev(element) {
        var sibling = element.previousElementSibling;
        while (sibling) {
            var list = sibling.querySelector("ul");
            if (list) {
                list.style.display = "none";
            }
            sibling = sibling.previousElementSibling;
        }
    }

    function hideNext(element) {
        var sibling = element.nextElementSibling;
        while (sibling) {
            var list = sibling.querySelector("ul");
            if (list) {
                list.style.display = "none";
            }
            sibling = sibling.nextElementSibling;
        }
    }

    function Accordion(selector) {
        var items = [];
        var accItem = document.querySelector(selector);

        accItem.addEventListener("click", function (ev) {
            if (!ev) {
                ev = window.event;
            }

            ev.stopPropagation;
            ev.preventDefault;

            var clickedItem = ev.target;
            if (!(clickedItem instanceof HTMLAnchorElement)) {
                return;
            }
            var list = clickedItem.nextElementSibling;

            hidePrev(clickedItem.parentNode);
            hideNext(clickedItem.parentNode);

            if (!list) {
                return;
            }

            if (list.style.display == "none") {
                list.style.display = "";
            }
            else {
                list.style.display = "none";
            }
        }, false);

        this.add = function (title) {
            var item = new Item(title);
            items.push(item);

            return item;
        }

        var list = document.createElement("ul");

        this.render = function () {
            while (accItem.firstChild) {
                accItem.removeChild(accItem.firstChild);
            }

            while (list.firstChild) {
                list.removeChild(list.firstChild);
            }

            for (var i = 0, len = items.length; i < len; i++) {
                var item = items[i].render();
                list.appendChild(item);
            }
            accItem.appendChild(list);

            return this;
        }

        this.serialize = function () {
            var serializedItems = [];
            for (var i = 0; i < items.length; i++) {
                serializedItems.push(items[i].serialize());
            }

            return serializedItems;
        }
    
    }

    function Item(title) {
        var items = [];

        this.add = function (title) {
            var item = new Item(title);
            items.push(item);

            return item;
        }

        

        this.render = function () {
            var item = document.createElement("li");
            item.innerHTML = "<a href='#' >" + title + "</a>";

            if (items.length > 0) {
                var sublist = document.createElement("ul");
                sublist.style.display = "none";

                for (var i = 0; i < items.length; i++) {
                    var subItem = items[i].render();
                    sublist.appendChild(subItem);
                }
                item.appendChild(sublist);
            }
            
            return item;
        }

        this.serialize = function () {
            var thisItem = {
                title: title
            }

            if (items.length > 0) {
                var serializedItems = [];
                for (var i = 0; i < items.length; i++) {
                    var serItem = items[i].serialize();
                    serializedItems.push(serItem);
                }

                thisItem.items = serializedItems;
            }

            return thisItem;
        }
    }

    function addItem(item, dataItem) {
        var accItem = item.add(dataItem.title);

        if (dataItem.items) {
            for (var i = 0; i < dataItem.items.length; i++) {
                addItem(accItem, dataItem.items[i]);
            }
        }
    }

    return {
        getAccordion: function(selector) {
            return new Accordion(selector);
        },

        getDeserializedAccordion: function (selector, data) {
            var accordion = this.getAccordion(selector);

            if (data) {
                for (var i = 0; i < data.length; i++) {
                    addItem(accordion, data[i]);
                }
            }

            return accordion;
        }
    }
}());
var controls = (function () {
    function removePrev(item) {
        var prev = item.previousElementSibling;
        
        while (prev) {
            var list = prev.querySelector("ul");
            if (list) {
                list.style.display = "none";
            }
            
            prev = prev.previousElementSibling;
        }
    }

    function removeNext(item) {
        var next = item.nextElementSibling;
        while (next) {
            var list = next.querySelector("ul");
            if (list) {
                list.style.display = "none";
            }

            next = next.previousElementSibling;
        }
    }

    function Accordion(selector) {
        var items = [];
        var wrapper = document.querySelector(selector);
        wrapper.addEventListener("click", function (ev) {
            if (!ev) {
                ev = window.event;                
            }

            ev.stopPropagation;
            ev.preventDefault;
            
            var clickedItem = ev.target;
            if (!(clickedItem instanceof HTMLAnchorElement)) {
                return;
            }

            removePrev(clickedItem.parentNode);
            removeNext(clickedItem.parentNode);

            var sublist = clickedItem.nextElementSibling;

            if (!sublist) {
                return;
            }

            if (sublist.style.display === "none") {
                sublist.style.display = "";
            }
            else {
                sublist.style.display = "none";
            }
        }, false);
        var list = document.createElement("ul");

        this.add = function (title) {
            var item = new Item(title);
            items.push(item);

            return item;
        }

        this.render = function () {
            while (list.firstChild) {
                list.removeChild(list.firstChild);
            }

            for (var i = 0; i < items.length; i++) {
                var item = items[i].render();
                list.appendChild(item);
            }
            wrapper.appendChild(list);
        }

        this.serialize = function () {
            var serializedItems = [];
            for (var i = 0; i < items.length; i++) {
                var serItem = items[i].serialize();
                serializedItems.push(serItem);
            }
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
            var listItem = document.createElement("li")
            listItem.innerHTML = '<a href="#">' + title + '</a>';

            if (items.length > 0) {
                var sublist = document.createElement("ul");
                sublist.style.display = "none";
                for (var i = 0, len = items.length; i < len; i += 1) {
                    var subItem = items[i].render();
                    sublist.appendChild(subItem);
                }

                listItem.appendChild(sublist);
            }

            return listItem;
        }

        this.serialize = function () {
            var thisItem = {
                title: title
            };

            if (items.length > 0) {
                var serializedItems = [];
                for (var i = 0; i < items.length; i += 1) {
                    var serItem = items[i].serialize();
                    serializedItems.push(serItem);
                }
                thisItem.items = serializedItems;
            }
            return thisItem;
        }
    }

    return {
        getAccordion: function (selector) {
            return new Accordion(selector);
        }
    }


}());
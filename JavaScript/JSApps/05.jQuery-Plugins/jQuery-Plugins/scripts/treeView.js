(function ($) {
    $.fn.treeView = function () {
        var elements = $(this.selector);

        for (var i = 0; i < elements.length; i++) {
            var list = $('ul', elements[i]);
            if (list) {
                for (var sublist = 0; sublist < list.length; sublist++) {
                    list[sublist].style.display = "none";
                }
                
            }
        }

        function hidePrev(item) {
            var prev = item.previousElementSibling;
            while (prev) {
                var sublist = prev.querySelector("ul");
                if (sublist) {
                    sublist.style.display = "none";
                }
                prev = prev.previousElementSibling;
            }
        }

        function hideNext(item) {
            var next = item.nextElementSibling;
            while (next) {
                var sublist = next.querySelector("ul");
                if (sublist) {
                    sublist.style.display = "none";
                }
                next = next.nextElementSibling;
            }
        }
        
        elements.on("click", function (ev) {
            ev.stopPropagation();
            ev.preventDefault();

            var anchor = ev.target;
            if (!(anchor instanceof HTMLAnchorElement)) {
                return;
            }

            hidePrev(anchor.parentNode);
            hideNext(anchor.parentNode);

            var sublist = anchor.nextElementSibling;

            if (!sublist) {
                return;
            }

            if (sublist.style.display === "none") {
                sublist.style.display = "";
            }
            else {
                sublist.style.display = "none";
            }
        });

        return this;
    }
}(jQuery))
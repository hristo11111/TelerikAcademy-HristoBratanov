var FavoritesBar = Class.create({
    init: function (folders, urls) {
        this.folders = folders;
        this.urls = urls;
    },

    render: function () {
        var wrapper = $('#wrapper')
        var favBar = $('<ul></ul>').appendTo(wrapper);
        
        for (var i = 0; i < this.folders.length; i++) {
            this.folders[i].render(favBar);
        }

        for (var i = 0; i < this.urls.length; i++) {
            this.urls[i].render(favBar);
        }
    }
});

var Folder = Class.create({
    init: function (title, urls) {
        this.title = title;
        this.urls = urls;
    },

    render: function (favbar) {
        var folder = $('<li>' + this.title + '</li>')
            .click(function () {
                if ($(this).children().css('display') == 'none') {
                    $(this).children().show()
                }
                else {
                    $(this).children().hide()
                }
                
            })
            .appendTo(favbar);
        var list = $('<ul></ul>').appendTo(folder);
        for (var i = 0; i < this.urls.length; i++) {
            this.urls[i].render(list);
        }
    }
});

var Url = Class.create({
    init: function (title, urlAddress) {
        this.title = title;
        this.urlAddress = urlAddress;
    },

    render: function (list) {
        var url = $('<li>' +
                            '<a href="' + this.urlAddress + '" target="_blank">' +
                                this.title +
                            '</a>' +
                         '</li>').appendTo(list);
    }
});

var telerikUrl1 = new Url("TelerikAcademy", "http://telerikacademy.com/");
var telerikUrl2 = new Url("TelerikAcademy Forum", "http://forums.academy.telerik.com/");
var telerikFolder = new Folder("Telerik", [telerikUrl1, telerikUrl2]);

var pmgUrl1 = new Url("Offical site", "http://www.pmg-sliven.com/bg/");
var pmgUrl2 = new Url("Contacts", "http://www.pmg-sliven.com/bg/");
var pmgFolder = new Folder("PMG", [pmgUrl1, pmgUrl2]);

var favBarUrl = new Url("Minestry of Education", "http://www.minedu.government.bg/news-home/");
var favBarUr2 = new Url("Actualno-education", "http://education.actualno.com/");

var favoritesBar = new FavoritesBar([telerikFolder, pmgFolder], [favBarUrl, favBarUr2]);

favoritesBar.render();
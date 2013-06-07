var Slider = {
    init: function (images, sliderHolder) {
        //this.buttons = buttons;
        this.images = images;
        this.sliderHolder = sliderHolder;
    },

    render: function () {
        //get images and set the first visible
        for (var i = 0; i < this.images.length; i++) {
            var img = $('<img />')
                .hide()
                .attr({ 'src': this.images[i].sourceThumb, 'bigSrc': this.images[i].sourceBig })
                .addClass('hidden')
                .on("click", images[i].enlarge)
                .appendTo($('#img-slider'));
                
            if (i == 0 || i == 1) {
                img.show().removeClass('hidden').addClass('visible');
            }
        }

        //create buttons holder
        var buttonsHolder = $('<div></div>')
            .addClass('btnHolder')
            .insertAfter($('#img-slider'));

        //initialise buttons
        var leftBtn = Object.create(Button);
        leftBtn.init("Previous", this.slideLeft);
        var leftDOMButton = $('<button></button>')
            .text(leftBtn.title)
            .on("click", leftBtn.action)
            .appendTo($('.btnHolder'));

        var rigthBtn = Object.create(Button);
        rigthBtn.init("Next", this.slideRight);
        var rigthDOMButton = $('<button></button>')
            .text(rigthBtn.title)
            .on("click", rigthBtn.action)
            .appendTo($('.btnHolder'));

        //create enlarged image holder
        var enlargedImgHolder = $('<div></div>')
            .attr('id', 'largeImgHolder')
            .insertAfter($('.btnHolder'));
    },

    slideLeft: function () {
        var imgs = $('#img-slider img');
        var index;
        for (var i = imgs.length; i > 1; i--) {
            if ($(imgs[i]).hasClass('visible')) {
                $(imgs[i]).hide()
                    .removeClass('visible')
                    .addClass('hidden');
                index = i - 1;
                break;
            }
        }

        for (var i = index; i >= 0; i--) {
            if ($(imgs[i]).hasClass('hidden')) {
                $(imgs[i]).show()
                    .removeClass('hidden')
                    .addClass('visible');
                break;
            }
        }
    },

    slideRight: function () {
        var imgs = $('#img-slider img');
        var index;
        for (var i = 0; i < imgs.length - 2; i++) {
            if ($(imgs[i]).hasClass('visible')) {
                $(imgs[i]).hide()
                    .removeClass('visible')
                    .addClass('hidden');
                index = i + 1;
                break;
            }
        }

        for (var i = index; i < imgs.length; i++) {
            if ($(imgs[i]).hasClass('hidden')) {
                $(imgs[i]).show()
                    .removeClass('hidden')
                    .addClass('visible');
                break;
            }
        }
    }
}

var Image = {
    init: function (title, sourceBig, sourceThumb) {
        this.title = title;
        this.sourceBig = sourceBig;
        this.sourceThumb = sourceThumb;
    },

    enlarge: function () {
        var images = $('.bigVisi');
        for (var i = 0; i < images.length; i++) {
            $(images[i]).remove();
        }

        var bigImage = $('<img />')
            .attr({ 'src': this.getAttribute('bigSrc') })
            .addClass("bigVisi")
            .show()
            .appendTo('#largeImgHolder');
    }
}

var Button = {
    init: function (title, action) {
        this.title = title;
        this.action = action;
    }
}


var sliderHolder = $("#img-slider");

var firstImage = Object.create(Image);
firstImage.init("bear", "images/bear.jpg", "images/bearThumb.jpg");
var secondImage = Object.create(Image);
secondImage.init("bear", "images/catanddog.jpg", "images/catanddogThumb.jpg");
var thirdImage = Object.create(Image);
thirdImage.init("bear", "images/eagle.jpg", "images/eagleThumb.jpg");
var forthImage = Object.create(Image);
forthImage.init("bear", "images/lion.jpg", "images/lionThumb.jpg");
var fifthImage = Object.create(Image);
fifthImage.init("bear", "images/monkey.jpg", "images/monkeyThumb.jpg");

var images = [firstImage, secondImage, thirdImage, forthImage, fifthImage];

var slider = Object.create(Slider);
slider.init(images, sliderHolder);
slider.render();
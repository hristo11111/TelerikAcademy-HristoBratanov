var SlideControler = (function () {
    var Slider = {
        init: function (slides, buttons) {
            this.slides = slides;
            this.buttons = buttons;
        },

        render: function (wrapper) {
            var slidesWrapper = $('<div></div>').addClass('slidesWrapper').appendTo(wrapper);
            for (var i = 0; i < this.slides.length; i++) {
                this.slides[i].render(slidesWrapper);
            }

            $('.slide').eq(0).addClass('visible').show();

            var buttonsWrapper = $('<div class="buttonsWrapper"></div>').appendTo(wrapper);
            for (var i = 0; i < this.buttons.length; i++) {
                this.buttons[i].render(buttonsWrapper);
            }

            $('.Next').on('click', this.next);
            $('.Previous').on('click', this.previous);
            window.setInterval(this.next, 5000);
        },

        next: function () {
            var slides = $('.slide');
            var index;
            for (var i = 0; i < slides.length-1; i++) {
                if ($(slides[i]).hasClass('visible')) {
                    $(slides[i]).hide()
                        .removeClass('visible')
                        .addClass('hidden');
                    index = i + 1;
                    break;
                }
            }

            for (var i = index; i < slides.length; i++) {
                if ($(slides[i]).hasClass('hidden')) {
                    $(slides[i]).show()
                        .removeClass('hidden')
                        .addClass('visible');
                    break;
                }
            }

        },

        

        previous: function () {
            var slides = $('.slide');
            var index;
            for (var i = slides.length; i > 0; i--) {
                if ($(slides[i]).hasClass('visible')) {
                    $(slides[i]).hide()
                        .removeClass('visible')
                        .addClass('hidden');
                    index = i - 1;
                    break;
                }
            }

            for (var i = index; i >= 0; i--) {
                if ($(slides[i]).hasClass('hidden')) {
                    $(slides[i]).show()
                        .removeClass('hidden')
                        .addClass('visible');
                    break;
                }
            }
        }
    };

    var Slide = {
        init: function (htmlCode) {
            this.htmlCode = htmlCode;
        },

        render: function (slidesWrapper) {
            $('<div class="slide"></div>')
                .html(this.htmlCode)
                .addClass('hidden')
                .hide()
                .appendTo(slidesWrapper);
        }
    };

    var Button = {
        init: function (name) {
            this.name = name;
        },

        render: function (buttonsWrapper) {
            $('<button></button>')
                .text(this.name)
                .addClass(this.name)
                .appendTo(buttonsWrapper);
        }
    }

    return {
        slider: Slider,
        slide: Slide,
        button: Button
    }

})();

$(document).ready(function () {
    setTimeout(function () {
        $('#dvData').fadeOut();
    }, 2000);
});



var SliderObject = SlideControler.slider;
var mySlider = Object.create(SliderObject);

var SlideObject = SlideControler.slide;
var slide1 = Object.create(SlideObject);
slide1.init('SLIDE1..........<!DOCTYPE html>' +
'<html>' +
'<head>' +
	'<title>MacBooks</title>' +
	'<meta charset="utf-8" />' +
'</head>' +
'<body>' +
	'<header>' +
		'<nav>' +
			'<a href="#" title="Apple">Apple</a>' +
			'<a href="#" title="Toshiba">Toshiba</a>' +
			'<a href="#" title="Lenovo">Lenovo</a>' +
			'<a href="#" title="Dell">Dell</a>' +
			'<a href="#" title="Asus">Asus</a>' +
			'<a href="#" title="Acer">Ace</a>' +
			'<a href="#" title="HP">HP</a>' +
		'</nav>' +
	'</header>' +
	'<hr size="1" width="1400" />' +
	'<section>' +
		'<table>' +
			'<tbody>' +
				'<tr>' +
					'<td>' +
						'<table border="1" cellspacing="0" cellpadding="3">' +
							'<tr>' +
								'<td>' +
									'<fieldset>' +
										'<legend>Apple MacBook Air</legend>' +
										'<table>' +
											'<tbody>' +
												'<tr>' +
													'<td rowspan="2">' +
														'<img src="images/MacBook.png" alt="MacBook" title="MacBook" />' +
													'</td>' +
													'<td>64GB SSD</td>' +
												'</tr>' +
												'<tr>' +
													'<td>2GB DDR</td>' +
												'</tr>' +
												'<tr>' +
													'<td>1300 USD</td>' +
													'<td>Intel Core i5</td>' +
												'</tr>' +
											'</tbody>' +
										'</table>' +
									'</fieldset>' +
								'</td>' +
								'<td>' +
									'<fieldset>' +
										'<legend>Apple MacBook Air</legend>' +
										'<table>' +
											'<tbody>' +
												'<tr>' +
													'<td rowspan="2">' +
														'<img src="images/MacBook.png" alt="MacBook" title="MacBook" />' +
													'</td>' +
													'<td>64GB SSD</td>' +
												'</tr>' +
												'<tr>' +
													'<td>2GB DDR</td>' +
												'</tr>' +
												'<tr>' +
													'<td>1300 USD</td>' +
													'<td>Intel Core i5</td>' +
												'</tr>' +
											'</tbody>' +
										'</table>' +
									'</fieldset>' +
								'</td>' +
							'</tr>' +
							'<tr>' +
								'<td>' +
									'<fieldset>' +
										'<legend>Apple MacBook Air</legend>' +
										'<table>' +
											'<tbody>' +
												'<tr>' +
													'<td rowspan="2">' +
														'<img src="images/MacBook.png" alt="MacBook" title="MacBook" />' +
													'</td>' +
													'<td>64GB SSD</td>' +
												'</tr>' +
												'<tr>' +
													'<td>2GB DDR</td>' +
												'</tr>' +
												'<tr>' +
													'<td>1300 USD</td>' +
													'<td>Intel Core i5</td>' +
												'</tr>' +
											'</tbody>' +
										'</table>' +
									'</fieldset>' +
								'</td>' +
							'</tr>' +
						'</table>' +
					'</td>' +
				'</tr>' +
			'</tbody>' +
		'</table>' +
	'</section>' +
'</body>' +
'</html>');

var slide2 = Object.create(SlideObject);
slide2.init('SLIDE2..........<!DOCTYPE html>' +
'<html>' +
'<head>' +
	'<title>MacBooks</title>' +
	'<meta charset="utf-8" />' +
'</head>' +
'<body>' +
	'<header>' +
		'<nav>' +
			'<a href="#" title="Apple">Apple</a>' +
			'<a href="#" title="Toshiba">Toshiba</a>' +
			'<a href="#" title="Lenovo">Lenovo</a>' +
			'<a href="#" title="Dell">Dell</a>' +
			'<a href="#" title="Asus">Asus</a>' +
			'<a href="#" title="Acer">Ace</a>' +
			'<a href="#" title="HP">HP</a>' +
		'</nav>' +
	'</header>' +
	'<hr size="1" width="1400" />' +
	'<section>' +
		'<table>' +
			'<tbody>' +
				'<tr>' +
					'<td>' +
						'<table border="1" cellspacing="0" cellpadding="3">' +
							'<tr>' +
								'<td>' +
									'<fieldset>' +
										'<legend>Apple MacBook Air</legend>' +
										'<table>' +
											'<tbody>' +
												'<tr>' +
													'<td rowspan="2">' +
														'<img src="images/MacBook.png" alt="MacBook" title="MacBook" />' +
													'</td>' +
													'<td>64GB SSD</td>' +
												'</tr>' +
												'<tr>' +
													'<td>2GB DDR</td>' +
												'</tr>' +
												'<tr>' +
													'<td>1300 USD</td>' +
													'<td>Intel Core i5</td>' +
												'</tr>' +
											'</tbody>' +
										'</table>' +
									'</fieldset>' +
								'</td>' +
							'</tr>' +
							'<tr>' +
								'<td>' +
									'<fieldset>' +
										'<legend>Apple MacBook Air</legend>' +
										'<table>' +
											'<tbody>' +
												'<tr>' +
													'<td rowspan="2">' +
														'<img src="images/MacBook.png" alt="MacBook" title="MacBook" />' +
													'</td>' +
													'<td>64GB SSD</td>' +
												'</tr>' +
												'<tr>' +
													'<td>2GB DDR</td>' +
												'</tr>' +
												'<tr>' +
													'<td>1300 USD</td>' +
													'<td>Intel Core i5</td>' +
												'</tr>' +
											'</tbody>' +
										'</table>' +
									'</fieldset>' +
								'</td>' +
							'</tr>' +
						'</table>' +
					'</td>' +
				'</tr>' +
			'</tbody>' +
		'</table>' +
	'</section>' +
'</body>' +
'</html>');

var slide3 = Object.create(SlideObject);
slide3.init('SLIDE3..........<!DOCTYPE html>' +
'<html>' +
'<head>' +
	'<title>MacBooks</title>' +
	'<meta charset="utf-8" />' +
'</head>' +
'<body>' +
	'<header>' +
		'<nav>' +
			'<a href="#" title="Apple">Apple</a>' +
			'<a href="#" title="Toshiba">Toshiba</a>' +
			'<a href="#" title="Lenovo">Lenovo</a>' +
			'<a href="#" title="Dell">Dell</a>' +
			'<a href="#" title="Asus">Asus</a>' +
			'<a href="#" title="Acer">Ace</a>' +
			'<a href="#" title="HP">HP</a>' +
		'</nav>' +
	'</header>' +
	'<hr size="1" width="1400" />' +
	'<section>' +
		'<table>' +
			'<tbody>' +
				'<tr>' +
					'<td>' +
						'<table border="1" cellspacing="0" cellpadding="3">' +
							'<tr>' +
								'<td>' +
									'<fieldset>' +
										'<legend>Apple MacBook Air</legend>' +
										'<table>' +
											'<tbody>' +
												'<tr>' +
													'<td rowspan="2">' +
														'<img src="images/MacBook.png" alt="MacBook" title="MacBook" />' +
													'</td>' +
													'<td>64GB SSD</td>' +
												'</tr>' +
												'<tr>' +
													'<td>2GB DDR</td>' +
												'</tr>' +
												'<tr>' +
													'<td>1300 USD</td>' +
													'<td>Intel Core i5</td>' +
												'</tr>' +
											'</tbody>' +
										'</table>' +
									'</fieldset>' +
								'</td>' +
							'</tr>' +
						'</table>' +
					'</td>' +
				'</tr>' +
			'</tbody>' +
		'</table>' +
	'</section>' +
'</body>' +
'</html>');

var ButtonObject = SlideControler.button;
var nextBtn = Object.create(ButtonObject);
nextBtn.init('Next');
var prevBtn = Object.create(ButtonObject);
prevBtn.init('Previous');

mySlider.init([slide1, slide2, slide3], [prevBtn, nextBtn]);
mySlider.render($('.wrapper'));
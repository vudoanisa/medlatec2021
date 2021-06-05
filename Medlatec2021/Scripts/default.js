(function($) {
    'use strict';

    $(document).ready(function() {
        //Banner
        if($('.banner-slider').length > 0) {
            $('.banner-slider').owlCarousel({
                autoplay: true,
                loop: true,
                nav: false,
                dots: true,
                lazyLoadEager: 1,
                lazyLoad: true,
                items: 1
            });
        }

        //Menu
        if($('.nav-menu').length > 0 && $(window).width() <= 1199) {
            $('.nav-menu').css('height', $(window).height() + 'px');
        }

        //Video
        if($('.video-slider').length > 0) {
            $('.video-slider').owlCarousel({
                autoplay: true,
                loop: true,
                nav: true,
                dots: false,
                lazyLoad: true,
                navText: ['<i class="arrow-left"></i>', '<i class="arrow-right"></i>'],
                responsive: {
                    0: {
                        items: 1,
                        lazyLoadEager: 1
                    },
                    768: {
                        items: 2,
                        lazyLoadEager: 2,
                        margin: 20
                    },
                    992: {
                        items: 3,
                        lazyLoadEager: 3,
                        margin: 20
                    },
                    1200: {
                        items: 4,
                        lazyLoadEager: 4,
                        margin: 20
                    }
                }
            });
        }

        //Doctor
        if($('.doctor-slider').length > 0) {
            $('.doctor-slider').owlCarousel({
                autoplay: true,
                loop: true,
                nav: true,
                dots: false,
                lazyLoad: true,
                navText: ['<i class="arrow-left"></i>', '<i class="arrow-right"></i>'],
                responsive: {
                    0: {
                        items: 1,
                        lazyLoadEager: 1
                    },
                    768: {
                        items: 2,
                        lazyLoadEager: 2,
                        margin: 20
                    },
                    992: {
                        items: 3,
                        lazyLoadEager: 3,
                        margin: 20
                    },
                    1200: {
                        items: 4,
                        lazyLoadEager: 4,
                        margin: 20
                    }
                }
            });
        }
    });

    //Search
    $(document).on('click', '.search-button', function() {
        $('.search-form').slideToggle();
    });

    $(window).resize(function() {
        //Menu
        if($('.nav-menu').length > 0 && $(window).width() <= 1199) {
            $('.nav-menu').css('height', $(window).height() + 'px');
        }
    });

    //Menu
    $(document).on('click', '.nav-button', function() {
        $('.nav-menu').toggleClass('nav-menu--active');
        $('body').toggleClass('no-scroll');
    });

    $(document).on('mouseup touchstart', function(e) {
        var container;

        //Menu
        if(!$(e.target).hasClass('nav-button') && !$(e.target).parent().hasClass('nav-button') && $(window).width() <= 1199) {
            container = $('.nav-menu');

            if(!container.is(e.target) && container.has(e.target).length === 0 && container.is(':visible')) {
                container.removeClass('nav-menu--active');
                $('body').removeClass('no-scroll');
            }
        }
    });

    $(document).on('click', '.nav-menu--wrapper .has-children > a i', function(e) {
        e.preventDefault();

        $(this).toggleClass('arrow-active');
        $(this).parent().next().slideToggle();
    });

    $(document).on('click', '.specialist-more a', function(e) {
        e.preventDefault();

        $('.specialist-list').toggleClass('specialist-list--active');
    });
})(jQuery);
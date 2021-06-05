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
        if($('.doctor-main.container .doctor-slider').length > 0) {
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

        if($('.specialist-child .doctor-slider').length > 0) {
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
                    1200: {
                        items: 3,
                        lazyLoadEager: 3,
                        margin: 20
                    }
                }
            });
        }


        if($('.schedule-date').length > 0) {
            $('.schedule-date').datepicker({
                format: 'dd/mm/yyyy'
            });
        }

        if($('.tab-customer--date').length > 0) {
            $('.tab-customer--date').datepicker({
                format: 'dd/mm/yyyy'
            });
        }

        if($('.return-find--data .data-date').length > 0) {
            $('.return-find--data .data-date').datepicker({
                format: 'dd/mm/yyyy'
            });
        }

        if($('#customer_birthday').length > 0) {
            $('#customer_birthday').datepicker({
                format: 'dd/mm/yyyy'
            });
        }

        if($('.find-doctor .find-doctor-date').length > 0) {
            $('.find-doctor .find-doctor-date').datepicker({
                format: 'dd/mm/yyyy'
            });
        }

        if($('.recruitment-online-wrapper .recruitment-birthday').length > 0) {
            $('.recruitment-online-wrapper .recruitment-birthday').datepicker({
                format: 'dd/mm/yyyy'
            });
        }

        if($('.schedule-form input.form-control').length > 0) {
            $('.schedule-form input.form-control').each(function () {
                if ($(this).val()){
                    $(this).addClass('not-empty');
                } else {
                    $(this).removeClass('not-empty');
                }
            }).keyup(function() {
                if ($(this).val()){
                    $(this).addClass('not-empty');
                } else {
                    $(this).removeClass('not-empty');
                }
            }).change(function() {
                if ($(this).val()){
                    $(this).addClass('not-empty');
                } else {
                    $(this).removeClass('not-empty');
                }
            });
        }

        if($('.register-form input.form-control').length > 0) {
            $('.register-form input.form-control').each(function () {
                if ($(this).val()){
                    $(this).prev().addClass('not-empty');
                } else {
                    $(this).prev().removeClass('not-empty');
                }
            }).keyup(function() {
                if ($(this).val()){
                    $(this).prev().addClass('not-empty');
                } else {
                    $(this).prev().removeClass('not-empty');
                }
            }).change(function() {
                if ($(this).val()){
                    $(this).prev().addClass('not-empty');
                } else {
                    $(this).prev().removeClass('not-empty');
                }
            });
        }

        if($('.return-find--data .form-control').length > 0) {
            $('.return-find--data .form-control').each(function () {
                if ($(this).val()){
                    $(this).addClass('not-empty');
                } else {
                    $(this).removeClass('not-empty');
                }
            }).keyup(function() {
                if ($(this).val()){
                    $(this).addClass('not-empty');
                } else {
                    $(this).removeClass('not-empty');
                }
            }).change(function() {
                if ($(this).val()){
                    $(this).addClass('not-empty');
                } else {
                    $(this).removeClass('not-empty');
                }
            });
        }

        if($('.return-form--feedback .form-control').length > 0) {
            $('.return-form--feedback .form-control').each(function () {
                if ($(this).val()){
                    $(this).addClass('not-empty');
                } else {
                    $(this).removeClass('not-empty');
                }
            }).keyup(function() {
                if ($(this).val()){
                    $(this).addClass('not-empty');
                } else {
                    $(this).removeClass('not-empty');
                }
            }).change(function() {
                if ($(this).val()){
                    $(this).addClass('not-empty');
                } else {
                    $(this).removeClass('not-empty');
                }
            });
        }

        if($('.schedule-service .schedule-radio--item input').length > 0 && $('.schedule-form .schedule-col-check').length > 0) {
            scheduleService();
        }

        if($('.customer-form-row label.customer-policy').length > 0 && $('#customer_policy').length > 0) {
            customerPolicy();
        }

        if($('.customer-form-row .customer-radio label').length > 0 && $('.customer-form-row .customer-radio input').length > 0) {
            customerSex();
        }

        if($('.customer-sidebar .customer-menu').length > 0) {
            clickSidebarMenu(0);
        }

        if($('.partner-slider').length > 0) {
            $('.partner-slider').owlCarousel({
                autoplay: true,
                loop: true,
                nav: true,
                dots: false,
                lazyLoad: true,
                autoplayHoverPause: true,
                navText: ['<i class="arrow-left"></i>', '<i class="arrow-right"></i>'],
                responsive: {
                    0: {
                        lazyLoadEager: 3,
                        items: 3,
                        margin: 3
                    },
                    992: {
                        lazyLoadEager: 4,
                        items: 4,
                        margin: 4
                    },
                    1200: {
                        lazyLoadEager: 5,
                        items: 5,
                        margin: 5
                    }
                }
            });
        }

        if($('.box-img-slider').length > 0) {
            $('.box-img-slider').owlCarousel({
                autoplay: true,
                loop: true,
                nav: true,
                dots: false,
                lazyLoadEager: 1,
                lazyLoad: true,
                items: 1,
                autoplayHoverPause: true,
                navText: ['<i class="arrow-left"></i>', '<i class="arrow-right"></i>']
            });
        }

        if($('.feedback-customer .feedback-slider').length > 0) {
            $('.feedback-customer .feedback-slider').owlCarousel({
                autoplay: true,
                loop: true,
                nav: true,
                dots: false,
                lazyLoad: true,
                autoplayHoverPause: true,
                navText: ['<i class="arrow-left"></i>', '<i class="arrow-right"></i>'],
                responsive: {
                    0: {
                        lazyLoadEager: 1,
                        items: 1
                    },
                    992: {
                        lazyLoadEager: 2,
                        items: 2,
                        margin: 30
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
        } else {
            $('.nav-menu').removeAttr('style');
        }

        if($('.customer-sidebar .customer-menu').length > 0) {
            clickSidebarMenu(0);
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

    $(document).on('click', '.price-service--more a', function(e) {
        e.preventDefault();

        $('.service-table').toggleClass('service-table--active');
    });

    $(document).on('click', '.turn-up--tab li', function() {
        var tab = $(this).attr('data-panel');
        $('.turn-up--tab li').removeClass('turn-up--active');
        $(this).addClass('turn-up--active');
        $('.turn-up--content').hide();
        $('#' + tab).fadeIn();
    });

    $(document).on('click', '.popup-click', function(e) {
        e.preventDefault();
        var elm = $(this).attr('data-popup');
        $('#' + elm).fadeIn();
    });

    $(document).on('click', '.popup-close', function(e) {
        e.preventDefault();
        $(this).parent().parent().fadeOut();
    });

    $(document).on('mouseup touchstart', function(e) {
        var container;

        if(!$(e.target).hasClass('popup-wrapper') && !$(e.target).parent().hasClass('popup-wrapper')) {
            container = $('.popup-wrapper');

            if(!container.is(e.target) && container.has(e.target).length === 0 && container.is(':visible')) {
                container.parent().fadeOut();
            }
        }
    });

    $(document).on('click', '.schedule-service .schedule-radio--item input[type="radio"]', function() {
        scheduleService();
    });

    $(document).on('click', '.customer-form-row label.customer-policy', function() {
        customerPolicy();
    });

    $(document).on('click', '.customer-radio input', function() {
        customerSex();
    });

    function scheduleService() {
        var show = $('.schedule-service .schedule-radio--item input:checked').attr('data-show');

        $('.schedule-form .schedule-col-check').each(function() {
            if($(this).attr('data-show') == show) {
                $(this).fadeIn();
            } else {
                $(this).hide();
            }
        });
    }

    function customerPolicy() {
        var checked = $('#customer_policy').is(':checked');
        var elm = $('.customer-form-row label.customer-policy');

        if(checked) {
            elm.addClass('customer-policy-active');
        } else {
            elm.removeClass('customer-policy-active');
        }
    }

    function customerSex() {
        var checked,
            elm;

        $('.customer-form-row .customer-radio label').removeClass('customer-radio-active');

        $('.customer-form-row .customer-radio input').each(function() {
            checked = $(this).is(':checked');
            elm = $(this).parent();

            if(checked) {
                elm.addClass('customer-radio-active');
            }
        });
    }

    $(document).on('click', '.customer-sidebar .customer-info', function() {
        $(this).toggleClass('customer-info--active');
        clickSidebarMenu(1);
    });

    function clickSidebarMenu(type) {
        if($(window).width() <= 991 && type == 1) {
            $('.customer-sidebar .customer-menu').slideToggle();
        } else {
            $('.customer-sidebar .customer-menu').removeAttr('style');
        }
    }

    $(document).on('click', '.accordion-item .accordion-item--head', function() {
        var parent = $(this).parent();
        parent.toggleClass('accordion-item-active');

        parent.find('.accordion-item--content').slideToggle();
    });

    $(document).on('click', '.map-toggle-btn', function() {
        $(this).toggleClass('map-toggle-active');
        $('.map-sidebar').toggleClass('map-sidebar-active');
    });

    $(document).on('click', '.body-blvp .see-more a', function(e) {
        e.preventDefault();
        $(this).toggleClass('active');
        $('.logo-bh.row').toggleClass('active');
    });
})(jQuery);
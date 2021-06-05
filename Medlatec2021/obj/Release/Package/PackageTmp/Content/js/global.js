// HienDT S2 PhuongMT 18/06/2014
function $$(id) { return document.getElementById(id); }
(function() {
    selfSearch = this;

    function slider() {
        var owl = $('.owl-carousel');
        owl.owlCarousel({
            margin: 12,
            loop: false,
            nav: true,
            dots: false,
            responsive: {
                0: {
                    items: 1
                },
                900: {
                    items: 1
                },
                1000: {
                    items: 2
                },
                1024: {
                    items: 3
                },
                1365: {
                    items: 4
                },
                1366: {
                    items: 5
                }
            }
        })
    }

    //xem them
   
    this.initHandlers = function() {
        slider();
        
    }

    this.initForm = function() {
        this.initHandlers();
    }
    this.initForm();
})();
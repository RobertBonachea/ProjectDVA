
jQuery(document).ready(function () {

  


    /*----------------------------------------------------*/
    /*	Superfish Mainmenu Section
    /*----------------------------------------------------*/

    jQuery(function () {
        jQuery('ul.sf-menu').stop().superfish();
    });



    /*----------------------------------------------------*/
    /*	Revolution Slider Nav Arrow Show Hide
    /*----------------------------------------------------*/

    jQuery('.fullwidthbanner-container').hover(function () {
        jQuery('.tp-leftarrow').stop().animate({
            "opacity": 1
        }, 'easeIn');
        jQuery('.tp-rightarrow').stop().animate({
            "opacity": 1
        }, 'easeIn');
    }, function () {
        jQuery('.tp-leftarrow').stop().animate({
            "opacity": 0
        }, 'easeIn');
        jQuery('.tp-rightarrow').stop().animate({
            "opacity": 0
        }, 'easeIn');
    }

    );







});
















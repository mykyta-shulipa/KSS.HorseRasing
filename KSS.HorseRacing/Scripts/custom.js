$(function () {
    var active = 'active';

    //get url parameter value from page URL
    var urlParam = function (name) {
        var results = new RegExp('[\\?&]' + name + '=([^&#]*)').exec(window.location.href);
        return results[1] || 0;
    };

    // Changes the cursor to an hourglass
    function cursorWait() {
        document.body.style.cursor = 'wait';
    }

    // Returns the cursor to the default pointer
    function cursorClear() {
        document.body.style.cursor = 'default';
    }

    $('.carousel').carousel();

    if ($(".validation").length > 0) {
        setInterval(function () {
            $(".valid").parents(".control-group").removeClass("error").addClass("success");
            $(".input-validation-error").parents(".control-group").removeClass("success").addClass("error");
        }, 50);
    }
    
    //pagination
    if ($(".content_with_pagination").length > 0) {
        (function () {
            // idea from http://jsfiddle.net/VHZqj/6/
            var showPerPage = parseInt($('#Pagination_RowsForPage').val());
            var pagesCount = parseInt($('#Pagination_PagesCount').val());
            var currentPage = parseInt($('#Pagination_CurrentPage').val());

            //get pagination
            function getPaginationLayout(perPage, countOfPages, currentPageNumber, selector) {
                if (currentPageNumber == 1) {
                    $("#previous_link").parents('li').addClass('disabled');
                }

                switch (countOfPages) {
                    case 1:
                        setText("pagination_most_left", currentPageNumber);
                        $("#pagination_most_left").parents('li').addClass('active');
                        $("#pagination_lefter").addClass('hide');
                        $("#pagination_center").addClass('hide');
                        $("#pagination_righter").addClass('hide');
                        $("#pagination_most_right").addClass('hide');
                        break;
                    case 2:
                        $("#pagination_center").addClass('hide');
                        $("#pagination_righter").addClass('hide');
                        $("#pagination_most_right").addClass('hide');
                        switch (currentPageNumber) {
                            case 1:
                                setText("pagination_most_left", currentPageNumber);
                                setText("pagination_lefter", currentPageNumber + 1);
                                $("#pagination_most_left").parents('li').addClass('active');
                                break;
                            case 2:
                                setText("pagination_most_left", currentPageNumber - 1);
                                setText("pagination_lefter", currentPageNumber);
                                $("#pagination_lefter").parents('li').addClass('active');
                                break;
                        }
                        break;
                    case 3:
                        $("#pagination_righter").addClass('hide');
                        $("#pagination_most_right").addClass('hide');
                        switch (currentPageNumber) {
                            case 1:
                                setText("pagination_most_left", currentPageNumber);
                                setText("pagination_lefter", currentPageNumber + 1);
                                setText("pagination_center", currentPageNumber + 2);
                                $("#pagination_most_left").parents('li').addClass('active');
                                break;
                            case 2:
                                setText("pagination_most_left", currentPageNumber - 1);
                                setText("pagination_lefter", currentPageNumber);
                                setText("pagination_center", currentPageNumber + 1);
                                $("#pagination_lefter").parents('li').addClass('active');
                                break;
                            case 3:
                                setText("pagination_most_left", currentPageNumber - 2);
                                setText("pagination_lefter", currentPageNumber - 1);
                                setText("pagination_center", currentPageNumber);
                                $("#pagination_center").parents('li').addClass('active');
                                break;
                        }
                        break;
                    case 4:
                        $("#pagination_most_right").addClass('hide');
                        switch (currentPageNumber) {
                            case 1:
                                setText("pagination_most_left", currentPageNumber);
                                setText("pagination_lefter", currentPageNumber + 1);
                                setText("pagination_center", currentPageNumber + 2);
                                setText("pagination_righter", currentPageNumber + 3);
                                $("#pagination_most_left").parents('li').addClass('active');
                                break;
                            case 2:
                                setText("pagination_most_left", currentPageNumber - 1);
                                setText("pagination_lefter", currentPageNumber);
                                setText("pagination_center", currentPageNumber + 1);
                                setText("pagination_righter", currentPageNumber + 2);
                                $("#pagination_lefter").parents('li').addClass('active');
                                break;
                            case 3:
                                setText("pagination_most_left", currentPageNumber - 2);
                                setText("pagination_lefter", currentPageNumber - 1);
                                setText("pagination_center", currentPageNumber);
                                setText("pagination_righter", currentPageNumber + 1);
                                $("#pagination_center").parents('li').addClass('active');
                                break;
                            case 4:
                                setText("pagination_most_left", currentPageNumber - 3);
                                setText("pagination_lefter", currentPageNumber - 2);
                                setText("pagination_center", currentPageNumber - 1);
                                setText("pagination_righter", currentPageNumber);
                                $("#pagination_righter").parents('li').addClass('active');
                                break;
                        }
                        break;
                    default:
                        // if numberOfPages >=5
                        switch (currentPageNumber) {
                            case 1:
                                setText("pagination_most_left", currentPageNumber);
                                setText("pagination_lefter", currentPageNumber + 1);
                                setText("pagination_center", currentPageNumber + 2);
                                setText("pagination_righter", currentPageNumber + 3);
                                setText("pagination_most_right", currentPageNumber + 4);

                                $("#pagination_most_left").parents('li').addClass('active');
                                break;
                            case 2:
                                setText("pagination_most_left", currentPageNumber - 1);
                                setText("pagination_lefter", currentPageNumber);
                                setText("pagination_center", currentPageNumber + 1);
                                setText("pagination_righter", currentPageNumber + 2);
                                setText("pagination_most_right", currentPageNumber + 3);

                                $("#pagination_lefter").parents('li').addClass('active');
                                break;
                            case countOfPages - 1:
                                setText("pagination_most_left", currentPageNumber - 3);
                                setText("pagination_lefter", currentPageNumber - 2);
                                setText("pagination_center", currentPageNumber - 1);
                                setText("pagination_righter", currentPageNumber);
                                setText("pagination_most_right", currentPageNumber + 1);
                                $("#pagination_righter").parents('li').addClass('active');
                                break;
                            case countOfPages:
                                setText("pagination_most_left", currentPageNumber - 4);
                                setText("pagination_lefter", currentPageNumber - 3);
                                setText("pagination_center", currentPageNumber - 2);
                                setText("pagination_righter", currentPageNumber - 1);
                                setText("pagination_most_right", currentPageNumber);

                                $("#pagination_most_right").parents('li').addClass('active');
                                break;
                            default:
                                setText("pagination_most_left", currentPageNumber - 2);
                                setText("pagination_lefter", currentPageNumber - 1);
                                setText("pagination_center", currentPageNumber);
                                setText("pagination_righter", currentPageNumber + 1);
                                setText("pagination_most_right", currentPageNumber + 2);
                                $("#pagination_center").parents('li').addClass('active');
                                break;
                        }
                }

                if (currentPageNumber == countOfPages) {
                    $("#next_link").parents('li').addClass('disabled');
                }

                function setText(idName, page) {
                    var elementWithClass = $(selector).find("#" + idName);
                    elementWithClass.text(page);
                }
            };

            if (pagesCount == 0) {
                pagesCount = 1;
            }
            if ($("#calls-table").length > 0) {
                getPaginationLayout(showPerPage, pagesCount, currentPage, "#calls-page-navigation");
            }
            if ($("#messages-table").length > 0) {
                getPaginationLayout(showPerPage, pagesCount, currentPage, "#messages-page-navigation");
            }
        })();
    }

    $("#sorting-table").tablesorter();
});

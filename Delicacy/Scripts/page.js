$.jqPaginator('#pagination1', {
    totalCounts: 100,
    pageSize: 9,
    visiblePages: 10,
    currentPage: 1,
    onPageChange: function (num, type) {
        $('#p1').text(type + '：' + num);
    }
});


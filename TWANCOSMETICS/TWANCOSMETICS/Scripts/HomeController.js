var homeconfig = {
    pageSize: 5,
    pageIndex: 1,
}
var homeController =
{
    init: function () {
        homeController.loadData();
    },
    loadData: function (changePageSize) {
        var keyword = $('#mySearch').val();
        $.ajax({
            url: '/Product/Search',
            type: 'GET',
            data: {

                keyword: keyword,
                page: homeconfig.pageIndex,
                pageSize: homeconfig.pageSize
            },
            dataType: 'json',
        })
        success: function (response) {
            var data = response.data;
            var html = '';
        }

    }
}

homeController.init();
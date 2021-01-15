


function deleteAdminProductItem(id) {
    $.ajax({
        url: "/Admin/Products/Delete/" + id + "/getCategories",
        type: "GET",
        success: function (res) {
            alertify.error("Xóa sản phẩm thành công !");
            $(".card-body").empty();
            $(".card-body").html(res);
        }
    })
}
function getCategoryToType() {
    var id = $("#producttype").val();
    var categories = "";
    $.ajax({
        url: "/Api/Categories/" + id + "/getCategories",
        type: "GET",
        success: function (res) {
            $(".category").empty();
            $.each(res, function (key, value) {
                categories += '<option value=' + value.id + '>' + value.name + '</option>';
            })
            $(".category").append(categories);
        }
    })
}
function search() {
    var category = $(".category").val();
    var publisher = $(".publisher").val();
    var product = $(".product").val();
    var data = {idcat: category, idpub: publisher, product: product };
    $.ajax({
        url: "/Admin/Products/Search",
        type: "GET",
        contentType: "charset=utf-8",
        dataType: "html",
        data: data,
        success: function (res) {
            $(".card-body").empty();
            $(".card-body").html(res);
        },
    })
}

function deleteAdminProductItem(id) {
    $.ajax({
        url: "/Admin/Products/Delete"+ id,
        type: "POST",
        success: function (res) {
            alertify.error("Xóa sản phẩm thành công !")
            $(".card-body").empty();
            $(".card-body").html(res);
        }
    })
}
function addToCart(id) {
    $.ajax({
        url: "/User/Cart/AddToCart/" + id,
        type: "GET",
        success: function (res) {
            alertify.success("Thêm sản phẩm vào giỏ hàng thành công !");
        }
    })
}
    function DeleteListItemCart(id) {
        $.ajax({
            url: "/User/Cart/RemoveItemCart/" + id,
            type: 'GET',
        }).done(function (res) {
            alertify.error("Xóa sản phẩm thành công !");
            updateCart(res);    
        });
    }
    function updateCart(res) {
        $("#list-cart").empty();
        $("#list-cart").html(res);
    }

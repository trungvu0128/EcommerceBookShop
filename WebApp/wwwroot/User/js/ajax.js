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
function getProductsByCategory(id) {
    var products = "";
    $.ajax({
        url: "/Api/Products/" + id + "/Category",
        success: function (res) {
            $(".products").empty();
            $.each(res, function (key, value) {
                products += '<div class="col-lg-4 col-md-6">' +
                    '<div class="product">' +
                    '<div class="flip-container">' +
                    '<div class="flipper">' +
                    '<div class="front"><a href="detail.html"><img src="img/product1.jpg" alt="" class="img-fluid"></a></div>' +
                    + '<div class="back"><a href="detail.html"><img src="img/product1_2.jpg" alt="" class="img-fluid"></a></div>'
                    + ' </div>' +
                    '</div><a href="detail.html" class="invisible"><img src="img/product1.jpg" alt="" class="img-fluid"></a>' +
                    '<div class="text">' +
                    '<h3><a href="detail.html">Fur coat with very but very very long name</a></h3>' +
                    '<p class="price">' +
                    '<del></del>$143.00' +
                       '</p >'+
                    '<p class="buttons"><a href="detail.html" class="btn btn-outline-secondary">View detail</a><a href="basket.html" class="btn btn-primary"><i class="fa fa-shopping-cart"></i>Add to cart</a></p>'+
                                    '</div >'+
                  '</div >'+
                '</div >'
            })
            $(".products").append(products);
        }
    })
}

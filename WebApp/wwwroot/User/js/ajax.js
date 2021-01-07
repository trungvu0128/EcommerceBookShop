function addToCart(id) {
    $.ajax({
        url: "/User/Cart/AddToCart/" + id,
        type: "GET",
        success: function (res) {
            alertify.success("Add success!");
        }
    })
}
function removeItemCart(id) {
    $.ajax({
        url: "/User/Cart/RemoveItemCart/" + id,
        type: "GET",
        success: function (res) {
            alertify.error("Remove success!");
        }
    })
    function updateCart(response) {
        $("#change-item-cart").empty();
        $("#change-item-cart").html(response);
        $("#total-quanty-show").text($("#total-quanty-card").val());
    }
}

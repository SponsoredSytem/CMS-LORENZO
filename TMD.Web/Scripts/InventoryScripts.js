﻿$(document).ready(function() {
    
});
function LoadProductByProductCode(control) {
    var productCode = $("#" + control.id).val();
    if (productCode != "" && productCode != "0") {
        $.ajax({
            url: "/Api/Product",
            type: "GET",
            data: { id: productCode },
            dataType: "json",
            success: ProductLoaded,
            error: function (textStatus, errorThrown) {
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        });
    }
}
function ProductLoaded(data) {
    $("#Barcode").val(data.ProductBarCode);
    $("#ProductName").val(data.Name);
    $("#SalePrice").val(data.SalePrice);
    $("#PurchasePrice").val(data.PurchasePrice);
    $("#ProductDescription").val(data.Comments);
    $("#ProductId").val(data.ProductId);
    $("#AvailableItems").val(data.AvailableItems);

    ShowProfit();
}
function LoadProductByBarCode() {
    alert("product loaded");
}
function CalculateProfit(from,to) {
    var profit=((to - from) / from) *100;
    return profit > 0 ? profit.toFixed(2) : 0;
}
function ShowProfit() {
    var fromValue = parseInt($("#PurchasePrice").val());
    var toValue = parseInt($("#SalePrice").val());
    var profit = CalculateProfit(isNaN(fromValue) ? 0 : fromValue, isNaN(toValue) ? 0 : toValue);
    $("#Profit").val(profit);
}
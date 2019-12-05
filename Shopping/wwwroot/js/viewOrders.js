function calculate() {
    var table = document.getElementById("orderitemstable");

    for (var i = 0; i < table.rows.length; i++) {
        var row = table.rows[i];
        var unitPrice = row.cells[4].childNodes[0].value;
        var prodQuantity = row.cells[5].childNodes[0].value;
        var answer = (Number(unitPrice) * Number(prodQuantity));
        row.cells[6].childNodes[0].value = answer;
    }

}
function updateOrder() {
    var products = [];
    var orderId = 0;
    var http = new XMLHttpRequest();

    var table = document.getElementById("orderitemstable");
    var checkBox = table.getElementsByTagName("input");
    for (var i = 1; i < checkBox.length; i++) {
        if (checkBox[i].checked) {
            var row = checkBox[i].parentNode.parentNode;
            var orditid = row.cells[0].innerText;
            var prodid = row.cells[1].innerText;
            var ordid = row.cells[2].innerText;
            var date = row.cells[3].childNodes[0].value;
            var uprice = row.cells[4].childNodes[0].value;
            var qty = row.cells[5].childNodes[0].value;
            var prodprice = row.cells[6].childNodes[0].value;

            orderId = parseInt(ordid);

            var ordersLineItem = {
                OrderItemId: parseInt(orditid),
                OrderItemDate: date,
                ProductId: parseInt(prodid),
                OrderitemUnitPrice: parseInt(uprice),
                OrderitemQuantity: parseInt(qty),
                OrderItemProductPrice: parseInt(prodprice),
            };

            products.push(ordersLineItem);
        }
    }



    order = {
        orderId: orderId,
        orderLineItems: products
    }

    console.log(JSON.stringify(order));
    http.open("POST", "../Orders/EditOrders", true);
    http.setRequestHeader("Content-Type", "application/json");
    http.send(JSON.stringify(order));
    alert("The Order Item has been updated Successfully!");
}

function deleteOrder() {
    var products = [];
    var orderId = 0;
    var http = new XMLHttpRequest();

    var table = document.getElementById("orderitemstable");
    var checkBox = table.getElementsByTagName("input");
    for (var i = 1; i < checkBox.length; i++) {
        if (checkBox[i].checked) {
            var row = checkBox[i].parentNode.parentNode;
            var orditid = row.cells[0].innerText;
            var prodid = document.getElementById("getproductid").innerText;
            var ordid = row.cells[2].innerText;
            var date = document.getElementById("getdate").value;
            var uprice = document.getElementById("getunitprice").value;
            var qty = document.getElementById("getquantity").value;
            var prodprice = document.getElementById("getproductprice").value;

            orderId = parseInt(ordid);

            var ordersLineItem = {
                OrderItemId: parseInt(orditid),
                OrderItemDate: date,
                ProductId: parseInt(prodid),
                OrderitemUnitPrice: parseInt(uprice),
                OrderitemQuantity: parseInt(qty),
                OrderItemProductPrice: parseInt(prodprice),
            };

            products.push(ordersLineItem);
        }
    }



    order = {
        orderId: orderId,
        orderLineItems: products
    }

    console.log(JSON.stringify(order));
    http.open("POST", "../Orders/DeleteOrder", true);
    http.setRequestHeader("Content-Type", "application/json");
    http.send(JSON.stringify(order));
    alert("The Order Item has been deleted Successfully!");
}

function deleteOrderLineRows() {
    var table = document.getElementById("orderitemstable");
    var checkBox = table.getElementsByTagName("input");
    var rowCount = checkBox.length;
    if (checkBox.checked) {
        table.deleteRows(rowCount - 1);
        rowCount--;
    }
}



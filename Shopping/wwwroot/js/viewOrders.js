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
    var http = new XMLHttpRequest();

    var table = document.getElementById("orderitemstable");
    for (var i = 1; i < table.rows.length; i++) {
        table.rows[i].onclick = function () {
            var orditid = this.cells[0].innerText;
            var prodid = this.cells[1].innerText;
            var ordid = this.cells[2].innerText;
            var date = this.cells[3].children[0].value;
            var uprice = this.cells[4].children[0].value;
            var qty = this.cells[5].children[0].value;
            var prodprice = this.cells[6].children[0].value;

            var orders = {
                OrderItemId: parseInt(orditid),
                ProductOrderDate: date,
                ProductId: parseInt(prodid),
                ProductQuantity: parseInt(qty),
                ProductPrice: parseInt(prodprice),
                OrderId: parseInt(ordid)

            };
            console.log(JSON.stringify(orders));
            http.open("POST", "../Orders/EditOrders", true);
            http.setRequestHeader("Content-Type", "application/json");
            http.send(JSON.stringify(orders));
            alert("The Order Item has been updated Successfully!");
        }
    }



}

function deleteOrder() {
    var http = new XMLHttpRequest();

    var table = document.getElementById("orderitemstable");
    for (var i = 1; i < table.rows.length; i++) {
        table.rows[i].onclick = function () {
            var orditid = this.cells[0].innerText;
            var date = document.getElementById("getdate").value;
            var uprice = document.getElementById("getunitprice").value;
            var prodid = document.getElementById("getproductid").innerText;
            var qty = document.getElementById("getquantity").value;
            var prodprice = document.getElementById("getproductprice").value;
            var ordid = document.getElementById("getorderid").innerText;


            var orders = {
                OrderItemId: parseInt(orditid),
                OrderitemDate: date,
                ProductId: parseInt(prodid),
                OrderitemUnitPrice: parseInt(uprice),
                OrderitemQuantity: parseInt(qty),
                OrderitemProductPrice: parseInt(prodprice),
                OrderId: parseInt(ordid)

            };
            console.log(JSON.stringify(orders));
            http.open("POST", "../Orders/DeleteOrder", true);
            http.setRequestHeader("Content-Type", "application/json");
            http.send(JSON.stringify(orders));
            alert("The Order Item has been deleted Successfully!");
        }
    }
    
}
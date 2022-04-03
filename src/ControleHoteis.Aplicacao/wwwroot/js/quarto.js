function CalculaQtdOcupantes() {
    $(".calculoOcupantes").blur(function () {
        var num1 = Number(document.getElementById("QtdAdultos").value);
        var num2 = Number(document.getElementById("QtdCriancas").value);
        document.getElementById("QtdOcupantes").value = num1 + num2;
    })
}
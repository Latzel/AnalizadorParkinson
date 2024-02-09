function getParametersByName(name) {

    if (name !== " " && name !== null && name !== undefined) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    } else {
        var arr = location.href.split("/");
        return arr[arr.length - 1];
    }
} 





function guardarPaciente() {

    var idPaciente = getParametersByName("idPaciente");

    $.ajax({
        type: "POST",
        url: UrlGuardarPaciente,
        async: true,
        data: {

            idPaciente: idPaciente,
            NombrePaciente: document.getElementById("nombre").value,
            ApellidoPaterno: document.getElementById("apePat").value,
            ApellidoMaterno: document.getElementById("apeMat").value,
            Edad: document.getElementById("edadP").value,
            Genero: document.getElementById("generoP").value


        },
        success: function (data) {

            location.href = "../home/listaPacientes";

            alert("Registro guardado correctamente");
        },
        error: function (xhr, status, error) {
            alert("Es necesario rellenar todos los campos");
        }
    });
}


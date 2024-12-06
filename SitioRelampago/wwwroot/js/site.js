
//Llenar el modal de Editar Area
document.querySelectorAll('.btn-tabla').forEach(button => {
    button.addEventListener('click', function () {
        const id = this.getAttribute('data-id');
        const nombre = this.getAttribute('data-nombre');

        document.getElementById('IdArea').value = id;
        document.getElementById('NombreArea').value = nombre;
    });
});


//Llenar el modal de eliminar Area 
document.querySelectorAll('.btn-tabla-eliminar').forEach(button => {
    button.addEventListener('click', function () {
        const id = this.getAttribute('data-id');
        const nombre = this.getAttribute('data-nombre');

        document.getElementById('IdAreaB').value = id;
        document.getElementById('NombreAreaB').value = nombre;
        
    });
});

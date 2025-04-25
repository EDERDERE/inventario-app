$(document).ready(function () {
    const baseUrl = '/Productos';  // Base URL para todas las acciones de productos

    // Cargar la lista de productos
    function loadProducts() {
        $.get(baseUrl, function (products) {
            $('#productList tbody').empty();
            products.forEach(product => {
                $('#productList tbody').append(`
                    <tr>
                        <td>${product.nombre}</td>
                        <td>${product.precio}</td>
                        <td>${product.cantidad}</td>
                        <td>
                            <button class="edit" data-id="${product.id}">Editar</button>
                            <button class="delete" data-id="${product.id}">Eliminar</button>
                        </td>
                    </tr>
                `);
            });
        });
    }

    // Agregar o actualizar un producto
    $('#productForm').submit(function (e) {
        console.log('ingreso a crear o actualizar')
        e.preventDefault();

        const id = $('#productId').val();
        const product = {
            nombre: $('#nombre').val(),
            descripcion: $('#descripcion').val(),
            precio: parseFloat($('#precio').val()),
            cantidad: parseInt($('#cantidad').val())
        };

        // Validación básica del formulario
        if (!product.nombre || !product.precio || product.precio <= 0 || product.cantidad <= 0) {
            alert('Por favor, ingresa los datos correctamente.');
            return;
        }

        if (id) {
            // Actualizar producto
            $.ajax({
                url: `${baseUrl}/Edit/${id}`,
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(product),
                success: function () {
                    loadProducts();
                    clearForm();
                },
                error: function () {
                    alert("Error al actualizar el producto");
                }
            });
        } else {
            // Agregar producto
            $.post(`${baseUrl}/Create`, product, function () {
                loadProducts();
                clearForm();
            }).fail(function () {
                alert("Error al crear el producto");
            });
        }
    });

    // Limpiar el formulario
    function clearForm() {
        $('#productId').val('');
        $('#nombre').val('');
        $('#descripcion').val('');
        $('#precio').val('');
        $('#cantidad').val('');
    }

    // Editar producto
    $(document).on('click', '.edit', function () {
        const id = $(this).data('id');
        $.get(`${baseUrl}/Edit/${id}`, function (product) {
            $('#productId').val(product.id);
            $('#nombre').val(product.nombre);
            $('#descripcion').val(product.descripcion);
            $('#precio').val(product.precio);
            $('#cantidad').val(product.cantidad);
        }).fail(function () {
            alert("Error al cargar los detalles del producto");
        });
    });

    // Eliminar producto
    $(document).on('click', '.delete', function () {
        const id = $(this).data('id');
        if (confirm('¿Estás seguro de eliminar este producto?')) {
            $.post(`${baseUrl}/Delete/${id}`, function () {
                loadProducts();
            }).fail(function () {
                alert("Error al eliminar el producto");
            });
        }
    });

    // Cargar productos al inicio
    loadProducts();
});

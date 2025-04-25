using System.ComponentModel.DataAnnotations;

public class Producto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres")]
    public string Nombre { get; set; }

    [StringLength(255, ErrorMessage = "La descripción no puede exceder los 255 caracteres")]
    public string Descripcion { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
    public decimal Precio { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
    public int Cantidad { get; set; }
}

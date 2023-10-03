using System.ComponentModel.DataAnnotations;

public class Aportes
{
    [Key]
    public int AporteId {get; set;}

    [Required(ErrorMessage ="Es obligatorio insertar el nombre completo de la persona en este campo")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage ="Debe de insertar un nombre valido")]
    public string? Persona {get; set;}

    [Required(ErrorMessage ="Debe de insertar una fecha")]
    public DateTime? Fecha {get; set;} = DateTime.Now;

    [Required(ErrorMessage ="Es obligatorio insertar una observacion")]
    [MinLength(5, ErrorMessage ="Debe de contener minimo {1} caracteres")]
    [MaxLength(100, ErrorMessage ="Debe de contener maximo {1} caracteres")]
    public string? Observacion {get; set;}

    [Required(ErrorMessage ="Debe de insertar un monto")]
    public double Monto {get; set;}
}
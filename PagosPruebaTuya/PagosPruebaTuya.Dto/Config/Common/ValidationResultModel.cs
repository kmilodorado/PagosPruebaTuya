using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace PagosPruebaTuya.Dto.Config.Common
{
    public class ValidationResultModel
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public List<ValidationError> Detalle { get; } 
        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Codigo = (int)HttpStatusCode.BadRequest;
            Mensaje = "Modelo invalido";
            Detalle = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();
        }
    }
}

namespace PagosPruebaTuya.V1.Dto.Enumerators
{
    public class Enumerators
    {
        public enum EnumStreetType
        {
            Avenida,
            Avenida_Calle,
            Avenida_Carrera,
            Calle,
            Carrera,
            Circular,
            Circunvalar,
            Diagonal,
            Manzana,
            Transversal,
            Via
        }

        public enum EnumStateOrden
        {
            En_proceso,
            Facturado,
            Enviando,
            Cancelado
        }

        public static string StateOrden(EnumStateOrden enumStateOrden)
        {
            switch (enumStateOrden)
            {
                case EnumStateOrden.En_proceso:
                    return "En proceso";
                case EnumStateOrden.Facturado:
                    return "Facturado";
                case EnumStateOrden.Enviando:
                    return "Enviado";
                case EnumStateOrden.Cancelado:
                    return "Cancelado";
                    default:
                    return "None";
            }
        }
       
    }
}

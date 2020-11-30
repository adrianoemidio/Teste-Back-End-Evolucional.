using System;

namespace AppEvolucional.Models
{

    /// <summary>
    /// Modelo de visualização dos erros
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

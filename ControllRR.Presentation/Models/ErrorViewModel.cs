namespace ControllRR.Presentation.Models;

public class ErrorViewModelxx
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

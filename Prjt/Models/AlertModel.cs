namespace Prjt.Models
{
    public class AlertModel
    {
        public Boolean isError { get; set; }
        public string Message { get; set; }

        public AlertModel() { }
        public AlertModel(Boolean isError, string Message)
        {
            this.isError = isError;
            this.Message = Message;
        }
    }
}
